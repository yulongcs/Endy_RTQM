using System;
using System.Collections.Generic;
using System.Linq;
using WebEzi.Base.DefinedData;

namespace WebEzi.Base.Extra
{
    public static class ExtraList
    {
        public static WEList<T> ToWEList<T>(this List<T> list)
        {
            var weList = new WEList<T>();

            foreach (var item in list)
            {
                weList.Add(item);
            }

            return weList;
        }

        public static WEList<T> ToWEList<T>(this IEnumerable<T> list)
        {
            var newList = list.ToList();

            var weList = new WEList<T>();

            foreach (var item in newList)
            {
                weList.Add(item);
            }

            return weList;
        }
    }
}
