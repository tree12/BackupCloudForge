using System;
using System.Collections.Generic;
using System.Text;

namespace ATom.CommonBasics.Extension
{
    public static class ArrayExtension
    {
        public static bool Any<T>(this T[,] arr,Func<T,bool> condition) {
            for(int i =0;i<arr.GetLength(0);i++)
                for (int j = 0; j < arr.GetLength(1); j++) {
                    if (condition(arr[i,j])) return true;
                }
            return false;
        }
    }
}
