using byForm_Server.ku.by.ToolClass;
using System;
using System.Collections.Generic;
using System.Linq;
namespace byForm_Server.ku.by.Object
{
    public class dictionary<K, V> : System.Collections.Generic.IEnumerable<byForm_Server.ku.by.Object.keyValue<K, V>>, System.Collections.IDictionary
    {
        private System.Collections.Generic.Dictionary<K, V> _dictionary;

        public dictionary()
        {
            _dictionary = new Dictionary<K, V>();
        }

        public dictionary(System.Collections.Generic.Dictionary<K, V> f_Source)
        {
            _dictionary = f_Source;
        }

        public V this[K key]
        {
            get
            {
                try
                {
                    return _dictionary[key];
                }
                catch (Exception ex)
                {
                    string tmpMessage = ex.Message;
                    throw new Exception(ErrorInfo.DictionaryError + tmpMessage);
                }
            }
            set
            {
                try
                {
                    _dictionary[key] = value;
                }
                catch(Exception ex)
                {
                    string tmpMessage = ex.Message;
                    throw new Exception(ErrorInfo.DictionaryError + tmpMessage);
                }
            }
        }

        public int count
        {
            get
            {
                return _dictionary.Count;
            }
        }

        public byForm_Server.ku.by.Object.ReadOnlyList<K> keys
        {
            get
            {
                return new ReadOnlyList<K>(this._dictionary.Keys.ToList());
            }
        }

        public byForm_Server.ku.by.Object.ReadOnlyList<V> values
        {
            get
            {
                return new ReadOnlyList<V>(this._dictionary.Values.ToList());
            }
        }

        public System.Collections.ICollection Keys
        {
            get
            {
                return this._dictionary.Keys;
            }
        }

        public System.Collections.ICollection Values
        {
            get
            {
                return this._dictionary.Values;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public int Count
        {
            get
            {
                return this._dictionary.Count;
            }
        }

        public object SyncRoot
        {
            get
            {
                return null;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object System.Collections.IDictionary.this[object key]
        {
            get
            {
                if (key == null)
                {
                    throw new Exception("dictionary 索引访问错误 值不能为null");
                }

                if (key is K)
                {
                    var tmpKey = (K)key;
                    return this[tmpKey];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (key == null)
                {
                    throw new Exception("dictionary 索引赋值错误 值不能为null");
                }

                if (key is K)
                {
                    var tmpKey = (K)key;
                    if (value is V)
                    {
                        var tmpValue = (V)value;
                        this[tmpKey] = tmpValue;
                    }
                    else
                    {
                        throw new Exception("dictionary 索引赋值错误 反序列化赋值类型不兼容");
                    }
                }
                else
                {
                    throw new Exception("dictionary 索引赋值错误 反序列化索引类型不兼容");
                }
            }
        }

        public void add(K key, V value)
        {
            try
            {
                this._dictionary.Add(key, value);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.DictionaryError + ex.Message);
            }
        }

        public void clear()
        {
            this._dictionary.Clear();
        }

        public bool containsKey(K key)
        {
            try
            {
                return this._dictionary.ContainsKey(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.DictionaryError + ex.Message);
            }
        }

        public bool containsValue(V value)
        {
            return this._dictionary.ContainsValue(value);
        }

        public bool remove(K key)
        {
            try
            {
                return this._dictionary.Remove(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.DictionaryError + ex.Message);
            }
        }

        public struct Enumrator : System.Collections.Generic.IEnumerator<byForm_Server.ku.by.Object.keyValue<K, V>>
        {
            private System.Collections.Generic.Dictionary<K, V> __dictionary;

            private byForm_Server.ku.by.Object.keyValue<K, V> current;

            private int index;

            internal Enumrator(System.Collections.Generic.Dictionary<K, V> f_Source)
            {
                __dictionary = f_Source;
                index = 0;
                current = default(keyValue<K, V>);
            }

            public byForm_Server.ku.by.Object.keyValue<K, V> Current
            {
                get
                {
                    return current;
                }
            }

            public void Dispose()
            {
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index == __dictionary.Count + 1)
                    {
                        throw new Exception("dictionary初始化错误");
                    }

                    return new keyValue<K, V>(current.key, current.value);
                }
            }

            public bool MoveNext()
            {
                if (index >= __dictionary.Count)
                {
                    current = default(keyValue<K, V>);
                    index = __dictionary.Count + 1;
                    return false;
                }
                var tmpKeyValuePair = __dictionary.ElementAt(index);
                current = new keyValue<K, V>(tmpKeyValuePair.Key, tmpKeyValuePair.Value);
                index++;
                return true;
            }

            public void Reset()
            {
                index = 0;
                current = default(keyValue<K, V>);
            }
        }

        public System.Collections.Generic.IEnumerator<byForm_Server.ku.by.Object.keyValue<K, V>> GetEnumerator()
        {
            return new Enumrator(_dictionary);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Enumrator(_dictionary);
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }

        public bool Contains(object key)
        {
            if (key == null)
            {
                throw new Exception("null value");
            }

            if (key is K)
            {
                return this._dictionary.ContainsKey((K)key);
            }
            else
            {
                throw new Exception("type error");
            }
        }

        public void Add(object key, object value)
        {
            try
            {
                this.add((K)key, (V)value);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInfo.DictionDeserializeError + ex.Message);
            }
        }

        public void Clear()
        {
            this.clear();
        }

        System.Collections.IDictionaryEnumerator System.Collections.IDictionary.GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }

        public void Remove(object key)
        {
            if (key == null)
            {
                throw new Exception();
            }

            this.remove((K)key);
        }

        public void CopyTo(System.Array array, int index)
        {
            throw new Exception("copyto is not supported in dictionary");
        }
    }
}
