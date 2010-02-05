using System;
using System.Collections;
using System.Collections.Generic;

namespace jeza.ioFTPD.Framework
{
    public class RaceStatsEnumerator<T> : IEnumerable<T>
    {
        public void Add (T item)
        {
            stats.Add (item);
        }

        public IEnumerator<T> GetEnumerator ()
        {
            foreach (T item in stats)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return GetEnumerator ();
        }

        private readonly List<T> stats = new List<T> ();
    }
}