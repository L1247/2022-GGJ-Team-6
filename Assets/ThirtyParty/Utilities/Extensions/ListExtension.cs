#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace AutoBot.Scripts.Utilities.Extensions
{
    public static class ListExtension
    {
    #region Public Methods

        public static void AddIfNotContains<T>(this List<T> list , T t)
        {
            if (list.Contains(t) == false) list.Add(t);
        }

        /// <summary>
        ///     Shuffles the element order of the specified list.
        /// </summary>
        public static void Shuffle<T>(this IList<T> ts)
        {
            var count = ts.Count;
            var last  = count - 1;
            for (var i = 0 ; i < last ; ++i)
            {
                var r   = Random.Range(i , count);
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }

    #endregion
    }
}