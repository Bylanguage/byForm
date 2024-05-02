using byForm_Server.ku.by.ToolClass;
using System;
using System.Collections.Generic;
using System.Linq;
namespace byForm_Server.ku.by.Object
{
    public class list<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.IList, System.Collections.Generic.IList<T>
    {
        private System.Collections.Generic.List<T> _list;

        public list()
        {
            _list = new System.Collections.Generic.List<T>();
        }

        public list(System.Collections.Generic.List<T> f_Source)
        {
            _list = f_Source;
        }

        public list(T[] f_Source)
        {
            _list = new List<T>(f_Source);
        }

        public list(byForm_Server.ku.by.Object.list<T> f_Source)
        {
            _list = new List<T>();

            foreach (var item in f_Source)
            {
                _list.Add(item);
            }
        }

        public T this[int index]
        {
            get
            {
                try
                {
                    return _list[index];
                }
                catch (Exception ex)
                {
                    throw new Exception(ErrorInfo.ListError + ex.Message);
                }
            }
            set
            {
                try
                {
                    _list[index] = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(ErrorInfo.ListError + ex.Message);
                }
            }
        }

        public int count
        {
            get
            {
                return _list.Count;
            }
        }

        public int Count
        {
            get
            {
                return ((ICollection<T>)_list).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<T>)_list).IsReadOnly;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object System.Collections.IList.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void add(T obj)
        {
            try
            {
                _list.Add(obj);
            }
            catch (Exception ex)
            {
                    throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public void addRange(T[] items)
        {
            try
            {
                var tmpList = items == null ? null : items.ToList();
                _list.AddRange(tmpList);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public void addRange(byForm_Server.ku.by.Object.list<T> items)
        {
            try
            {
                _list.AddRange(items == null ? null : items._list);
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public void insert(int index, T item)
        {
            try
            {
                _list.Insert(index,item);
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public void clear()
        {
            try
            {
                _list.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public bool contains(T item)
        {
            try
            {
                return _list.Contains(item);
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public int indexOf(T item)
        {
            try
            {
                return _list.IndexOf(item);
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public int lastIndexOf(T item)
        {
            try
            {
                return _list.LastIndexOf(item);
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public void remove(T item)
        {
            try
            {
                _list.Remove(item);
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public void removeAt(int index)
        {
            try
            {
                _list.RemoveAt(index);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public T[] toArray()
        {
            try
            {
                return _list.ToArray();
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_list).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_list).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)_list).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)_list).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)_list).RemoveAt(index);
        }

        public void Add(T item)
        {
            ((ICollection<T>)_list).Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)_list).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)_list).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)_list).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)_list).Remove(item);
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }

        int System.Collections.IList.Add(object value)
        {
            try
            {
                _list.Add((T)value);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }

            return count - 1;
        }

        bool System.Collections.IList.Contains(object value)
        {
            try
            {
                return _list.Contains((T)value);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        int System.Collections.IList.IndexOf(object value)
        {
            try
            {
                return _list.IndexOf((T)value);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        void System.Collections.IList.Insert(int index, object value)
        {
            try
            {
                _list.Insert(index, (T)value);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        void System.Collections.IList.Remove(object value)
        {
            try
            {
                _list.Remove((T)value);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ListError + ex.Message);
            }
        }

        public void CopyTo(System.Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}
