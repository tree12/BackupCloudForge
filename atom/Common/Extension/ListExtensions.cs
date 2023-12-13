using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrazyTeam.DarkMagick;

namespace  ATom.CommonBasics.Extension
{
	public static class ListExtensions
	{
		public static List<List<T>> Split<T>(this List<T> items, int sliceSize = 30)
		{
			List<List<T>> list = new List<List<T>>();
			for (int i = 0; i < items.Count; i += sliceSize)
				list.Add(items.GetRange(i, Math.Min(sliceSize, items.Count - i)));
			return list;
		}

	    public static List<T> DeepCloneEverythingInList<T>(this List<T> list)
	    {
	        List<T> cloneResultList = new List<T>(list.Count);
	        foreach (T o in list)
	        {
	            cloneResultList.Add((T)o.CloneDeep());
	        }
	        return cloneResultList;
	    }

        public static List<T> CloneEverythingInList<T>(this List<T> list) where T:ICloneable { 
            List<T> cloneResultList = new List<T>(list.Count);
            foreach (T o in list)
            {
                cloneResultList.Add((T) o.Clone());
            }
            return cloneResultList;
        }

	    public static T PreviousElement<T>(this List<T> list, T currentElement) {
	        if (list == null || !list.Any()) return default(T);
	        if (list.Count == 1) return list.FirstOrDefault();
	        int i = list.IndexOf(currentElement);
	        if (i == 0) return list.LastOrDefault();
	        else return list[i - 1];
	    }

        public static T NextElement<T>(this List<T> list, T currentElement)
        {
            if (list == null || !list.Any()) return default(T);
            if (list.Count == 1) return list.FirstOrDefault();
            int i = list.IndexOf(currentElement);
            if (i >= list.Count-1) return list.FirstOrDefault();
            else return list[i + 1];
        }

	    public static bool HaveDifferentElements<T>(this List<T> currentList, List<T> otherList)
	    {
	        if (currentList == null && otherList == null) return false;
            if (currentList==null || otherList == null) return true;
	        if (currentList.Count != otherList.Count) return true;
	        return currentList.Intersect(otherList).Count() != currentList.Count;

	    }
    }
}
