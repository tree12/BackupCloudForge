using System;
using System.Collections.Generic;
using System.Text;

namespace ATom.CommonBasics.Extension
{
    public static class DictionaryExtension
    {
        public static void AddRange<K, V>(this Dictionary<K, V> me, Dictionary<K, V> dictToAdd, bool replace = true) {
            foreach (KeyValuePair<K, V> keyValue in dictToAdd) {
                if (me.ContainsKey(keyValue.Key) && !replace)  continue;
                me[keyValue.Key] = keyValue.Value;
            }
        }
    }
}
