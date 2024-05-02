using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class keyValue<K, V>
    {
        public keyValue(K key, V value)
        {
            this.key = key; this.value = value;
        }

        public K key { get; set; }

        public V value { get; set; }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
