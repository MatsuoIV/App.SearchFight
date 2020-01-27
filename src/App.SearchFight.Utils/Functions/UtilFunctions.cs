﻿using System;
using System.Collections.Generic;

namespace App.SearchFight.Utils.Functions
{
    public static class UtilFunctions
    {
        public static T GetMax<T>(this IEnumerable<T> source, Func<T, long> func)
        {
            if (source == null)
                throw new ArgumentException("The specified parameter cannot be null.", nameof(source));

            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    throw new ArgumentException("Cannot get next enumerator from specified parameter.", nameof(source));

                long currentMax = func(enumerator.Current);
                T maxItem = enumerator.Current;

                while (enumerator.MoveNext())
                {
                    long possible = func(enumerator.Current);

                    if (currentMax < possible)
                    {
                        currentMax = possible;
                        maxItem = enumerator.Current;
                    }
                }
                return maxItem;
            }
        }
    }
}
