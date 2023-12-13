using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CrazyTeam.DarkMagick;



namespace CrazyTeam.Shared.Database
{
    /*
    public abstract class ObjectCacheBase {

        static private List<ObjectCacheBase> _allCaches = new List<ObjectCacheBase>();
        static private Dictionary<Type,ObjectCacheBase> _allCachesDict = new Dictionary<Type, ObjectCacheBase>();

        protected Dictionary<object, WeakReference> cache = new Dictionary<object, WeakReference>();

        public ObjectCacheBase() {
            lock (_allCachesDict) {
                _allCaches.Add(this);
            }
        }

        public abstract void ClearCache();

        public static void ClearCacheAll()
        {
            foreach (ObjectCacheBase objectCacheBase in _allCaches) {
                objectCacheBase.ClearCache();
            }
        }

        ~ObjectCacheBase() {
            _allCaches.Remove(this);
            foreach (KeyValuePair<Type, ObjectCacheBase> pair in _allCachesDict) {
                if(pair.Value!=this) continue;
                _allCachesDict.Remove(pair.Key);
                break;
            }
        }

        public abstract BaseDataObject GetDataObjectBase(BaseDataObject baseDataObject, bool refreshEvenIfComplete = false);

        public static ObjectCacheBase GetCacheForType(Type type,bool createInstance=false) {
            lock (_allCachesDict) {
                if (_allCachesDict.ContainsKey(type)) {
                    if (!createInstance || _allCachesDict[type]!=null) return _allCachesDict[type];
                }
                ObjectCacheBase cacheForType =
                    _allCaches.FirstOrDefault(_ => _.GetType().GetGenericArguments().First() == type);

                if (cacheForType == null && createInstance) {
                    cacheForType =
                        (ObjectCacheBase) Activator.CreateInstance(typeof (ObjectCache<>).MakeGenericType(type));
                }
                if (cacheForType == null && createInstance) {
                    throw new Exception("Could not create Cache for type " + type.FullName);
                }

                _allCachesDict[type] = cacheForType;
                return cacheForType;
            }
        }
       

        static public void RemoveFromCache(Type type, object keyValue) {
            ObjectCacheBase cacheToRemove =
                GetCacheForType(type);
            if (cacheToRemove!=null) {
                cacheToRemove.RemoveFromCache(keyValue);
            }
        }

        public void RemoveFromCache(object keyValue)
        {
            if (cache.ContainsKey(keyValue))
                cache.Remove(keyValue);
        }
    }

    public class ObjectCache<T> : ObjectCacheBase where T:BaseDataObject, new() {                

#if !MOBILE
        private static Dictionary<Type, Type[]> dictToRemoting=new Dictionary<Type, Type[]>();
        private static Type _remotingType;
#endif        

        static ObjectCache() {
#if !MOBILE
            if (CodeLocation.Location == CodeLocationEnum.LOCATION_CLIENT)
                _remotingType = TypeExtensions.FindType("CCSS.Client.Remoting");
#endif
        }

        public override void ClearCache() {
            cache.Clear();
        }


        public override BaseDataObject GetDataObjectBase(BaseDataObject baseDataObject, bool refreshEvenIfComplete = false) {
            return GetDataObject(baseDataObject, refreshEvenIfComplete);
        }


        public T GetDataObject(BaseDataObject baseDataObject, bool refreshEvenIfComplete=false) {
            if (baseDataObject == null) return null;
            T obj = baseDataObject as T;
            if (obj == null)
            {
                obj = baseDataObject.ConvertTo<T>();
            }
            else if (baseDataObject.ObjectState == ObjectState.Complete && !refreshEvenIfComplete) return obj;
            if (!obj.HasKeyValue)
            {
                return obj;
            }
            object keyValue = obj.KeyValue;
            T target = null;
            if (cache.ContainsKey(keyValue) && cache[keyValue].IsAlive)
            {
                target = (T)cache[keyValue].Target;
                return target;
            }

            target = (T) obj.GetRemoting().GetDataObject(obj);

            if (target == null)
            {
                CBLog.Debug("GetDataObject gescheitert für " + obj.GetType() + "; " + obj);
                target = new T();
            }
            cache[baseDataObject.KeyValue] = new WeakReference(target);
            return target;
        }



#if !MOBILE
        private Type[] GetRemotingTypeForServer(BaseDataObject basedataObject) {
            Type baseType = basedataObject.GetType();
            if (!dictToRemoting.ContainsKey(baseType))
            {
                RemotingAttribute remotingAttribute =
                    (RemotingAttribute)baseType.GetCustomAttributes(typeof(RemotingAttribute), false).FirstOrDefault();
                Type interType = TypeExtensions.FindType("CCSS.Interface.RemotingInterfaces.IBaseDataObject`1");
                Type generic = interType.MakeGenericType(basedataObject.GetType());
                HashSet<Type> subTypes = null;
                if (remotingAttribute != null)
                {
                    subTypes = remotingAttribute.Type.GetFinalSubTypes(TypeExtensions.TypesSelection.Class);                    
                }
                else
                {
                    subTypes = generic.GetFinalSubTypes(TypeExtensions.TypesSelection.Class);
                }
                if (subTypes.Count == 0)
                {
                    throw new Exception("Konnte das Remoting am Server für " + baseType + " nicht ermitteln.");
                }
                else if (subTypes.Count > 1)
                {
                    throw new Exception("Konnte das Remoting am Server für " + baseType +
                                         " nicht ermitteln da es mehrer Möglichkeiten gibt.");
                }
                dictToRemoting[baseType] = new[] { subTypes.First(), generic };
            }
            return dictToRemoting[baseType];           
        }

#endif

        public List<T> EnsureAllElementsLoaded(IEnumerable<BaseDataObject> list) {
            List<T> ret;
            int count = list.Count();
            bool isNewList = false;
            if (list is List<T>) ret = (List<T>) list;
            else {
                ret = new List<T>(count);
                isNewList = true;
            }            
            for (int i = 0; i < count; i++)
            {
                T t = GetDataObject(list.ElementAt(i));
                if (isNewList) ret.Add(t);
                else ret[i] = t;
            }
            return ret;
        }

        public void AddToCache(List<T> lstReturn) {
            foreach (T o in lstReturn) {
                cache[o.KeyValue] = new WeakReference(o);
            }
        }

        public void AddToCache(T o)
        {            
            cache[o.KeyValue] = new WeakReference(o);            
        }
    }*/
}
