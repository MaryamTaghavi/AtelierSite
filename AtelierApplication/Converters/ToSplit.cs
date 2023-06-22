using System;
using System.Collections.Generic;

namespace Atelier.Application.Converters
{
    public static class ToSplit
    {
        public static List<List<int>> SplitList(List<int> locations, int nSize = 30)
        {
            var list = new List<List<int>>();

            for (int i = 0; i < locations.Count; i += nSize)
            {
                list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
            }

            return list;
        }

        public static string ToFixed(this double number, uint decimals,bool replace=false)
        {
           // if (replace)
             //   return number.ToString("N" + decimals).Replace('.','/');

           // else
                return number.ToString("N" + decimals);
        }
        public static string ToFixed(this decimal number, int decimals)
        {
            return number.ToString("N" + decimals);
        }

        public static string ToFixedPrint(this decimal number, int decimals, bool replace)
        {
            return replace ? number.ToString("N" + decimals).Replace('/', '.') : number.ToString("N" + decimals).Replace('.', '/');
        }

        public static string ToFixed(this float number, uint decimals, bool replace = false)
        {
            return number.ToString("N" + decimals);
        }
    }
}