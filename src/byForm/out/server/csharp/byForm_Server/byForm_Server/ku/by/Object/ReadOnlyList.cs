using byForm_Server.ku.by.ToolClass;
using System;
using System.Collections.Generic;
using System.Linq;
namespace byForm_Server.ku.by.Object
{
    public class ReadOnlyList<T> : System.Collections.Generic.IEnumerable<T>
    {
        private readonly System.Collections.Generic.List<T> value;

        public ReadOnlyList(System.Collections.Generic.List<T> list)
        {
            this.value = list;
        }

        public ReadOnlyList(T[] items)
        {
            this.value = items.ToList();
        }

        public ReadOnlyList(byForm_Server.ku.by.Object.list<T> items)
        {
            this.value = items.toArray().ToList();
        }

        public int count
        {
            get
            {
                return this.value.Count;
            }
        }

        public bool contains(T item)
        {
            try
            {
                return this.value.Contains(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ReadonlyListError + ex.Message);
            }
        }

        public int indexOf(T item)
        {
            try
            {
                return this.value.IndexOf(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ReadonlyListError + ex.Message);
            }
        }

        public int lastIndexOf(T item)
        {
            try
            {
                return this.value.LastIndexOf(item);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ErrorInfo.ReadonlyListError + ex.Message);
            }
        }

        public T[] toArray()
        {
            try
            {
                return this.value.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.ReadonlyListError + ex.Message);
            }
        }

        public byForm_Server.ku.by.Object.list<T> toList()
        {
            var tmpNewValue = this.value.ToList();
            return new list<T>(tmpNewValue);
        }

        public T this[int index]
        {
            get
            {
                try
                {
                    return this.value[index];
                }
                catch (Exception ex)
                {
                    throw new Exception(ErrorInfo.ReadonlyListError + ex.Message);
                }
            }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)value).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)value).GetEnumerator();
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
