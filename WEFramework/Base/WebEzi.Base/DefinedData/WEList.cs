using System.Collections;
using System.Collections.Generic;
using System;

namespace WebEzi.Base.DefinedData
{
    [Serializable]
    public class WEList<T> : IList<T>
    {
        protected IList<T> list;

        public WEList()
        {
            this.list = new List<T>();
        }

        #region IList<T> member

        public int IndexOf(T item)
        {
            return this.list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.list.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return this.list[index]; }
            set { this.list[index] = value; }
        }

        #endregion

        #region ICollection<T> mebmer

        public void Add(T item)
        {
            this.list.Add(item);
        }

        public bool Remove(T item)
        {
            return this.list.Remove(item);
        }

        public bool Contains(T item)
        {
            return this.list.Contains(item);
        }

        public void CopyTo(T[] array, int arryIndex)
        {
            this.list.CopyTo(array, arryIndex);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public bool IsReadOnly
        {
            get { return this.list.IsReadOnly; }
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        #endregion

        #region IEnumerable<T> member

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable member

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        #endregion
    }
}
