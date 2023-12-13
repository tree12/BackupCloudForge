using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ATom.CommonBasics.Collections
{



    public class WaitCollector<T, O> {

        protected Dictionary<T, CTTuple<T, Timer>> dictDelayedAction = new Dictionary<T, CTTuple<T, Timer>>();

        protected Dictionary<T, List<O>> _collectListDict = new Dictionary<T, List<O>>();

        private Dictionary<T, DateTime> _nextPossibleRunTimeDict = new Dictionary<T, DateTime>();  //Muss man noch aufräumen in den Keys. Mögliches MemoryLeak... 

        protected long GetNextRunTimeDistance(T t) {
            foreach (KeyValuePair<T, DateTime> keyValuePair in _nextPossibleRunTimeDict.ToList()) {
                if (keyValuePair.Value < DateTime.Now) _nextPossibleRunTimeDict.Remove(keyValuePair.Key);
            }
            if (!_nextPossibleRunTimeDict.ContainsKey(t)) return 0;
            return (long) (_nextPossibleRunTimeDict[t]-DateTime.Now).TotalMilliseconds;
        }

        

        /// <summary>
        /// Die Aktion wird nach der beim ersten Aufruf festgelegten Zeit ausgeführt. 
        /// Wird sie dazwischen mehrmals mit dem selben Object aufgerufen, wird zwar das Objekt aktualisiert mit welchem die Aktion durchgeführt wird, ansonsten bleibt alles gleich.
        /// </summary>
        /// <param name="o">Object mit dem die Aktion durchgeführt wird, bzw. für welches "Zusammengewartet" wird.</param>
        /// <param name="delayTimeInMs">Zeit in ms</param>
        /// <param name="collectObject">Object das in Liste gespeichert werden soll</param>
        /// <param name="a">Aktion</param>    
        public void AddExecute(T o, long delayTimeInMs, O collectObject,
            Action<T, List<O>> a) {
            AddExecute(o,delayTimeInMs,0,collectObject,a);
        }

        /// <summary>
        /// Die Aktion wird nach der beim ersten Aufruf festgelegten Zeit ausgeführt. 
        /// Wird sie dazwischen mehrmals mit dem selben Object aufgerufen, wird zwar das Objekt aktualisiert mit welchem die Aktion durchgeführt wird, ansonsten bleibt alles gleich.
        /// </summary>
        /// <param name="o">Object mit dem die Aktion durchgeführt wird, bzw. für welches "Zusammengewartet" wird.</param>
        /// <param name="delayTimeInMs">Zeit in ms</param>
        /// <param name="collectObject">Object das in Liste gespeichert werden soll</param>
        /// <param name="a">Aktion</param>    
        public void AddExecute(T o, long delayTimeInMs, long minDistanceBetweenRun, O collectObject, Action<T,List<O>> a) {
            lock (dictDelayedAction) {
                if (collectObject != null) {
                    if (!_collectListDict.ContainsKey(o)) _collectListDict[o] = new List<O>();
                    _collectListDict[o].Add(collectObject);
                }

                Timer t = new Timer((arg) => {
                    T keyO = (T) arg;
                    T aktO;
                    List<O> list = null;
                    lock (dictDelayedAction) {
                        if (!dictDelayedAction.ContainsKey(keyO)) return;
                        aktO = dictDelayedAction[keyO].Item1;
                        dictDelayedAction.Remove(keyO);
                        if (_collectListDict.ContainsKey(keyO)) {
                            list = _collectListDict[keyO];
                            _collectListDict.Remove(keyO);
                        }
                        if (minDistanceBetweenRun > 0)
                            _nextPossibleRunTimeDict[aktO] = DateTime.Now.AddMilliseconds(minDistanceBetweenRun);
                    }
                    a(aktO, list);
                }, o, Math.Max(GetNextRunTimeDistance(o), delayTimeInMs), System.Threading.Timeout.Infinite);

                if (dictDelayedAction.ContainsKey(o)) {
                    dictDelayedAction[o].Item1 = o; //update item, keep action                    
                    dictDelayedAction[o].Item2.Change(-1, -1);
                    dictDelayedAction[o].Item2.Dispose();
                    dictDelayedAction[o].Item2 = t;
                }
                else {
                    dictDelayedAction[o] = new CTTuple<T, Timer>(o,t);                    
                }
            }

        }
    }

    public class WaitCollector<T> : WaitCollector<T,Object>
        {


        /// <summary>
        /// Die Aktion wird nach der beim ersten Aufruf festgelegten Zeit ausgeführt. 
        /// Wird sie dazwischen mehrmals mit dem selben Object aufgerufen, wird zwar das Objekt aktualisiert mit welchem die Aktion durchgeführt wird, ansonsten bleibt alles gleich.
        /// </summary>
        /// <param name="o">Object mit dem die Aktion durchgeführt wird, bzw. für welches "Zusammengewartet" wird.</param>
        /// <param name="timeInMs">Zeit in ms</param>
        /// <param name="a">Aktion</param>        
        public void AddExecute(T o, long timeInMs, Action<T> a) {
            AddExecute(o, timeInMs, null, (oa, list) => a(oa));
        }

        public void AddExecute(T o, long delaytimeInMs, long minTimeBetween2Runs, Action<T> a)
        {
            AddExecute(o, delaytimeInMs, minTimeBetween2Runs, null, (oa, list) => a(oa));
        }
    }
}
