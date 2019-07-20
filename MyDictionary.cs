using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAndDic0710_1
{
    /// <summary>
    /// 字典的底层实现，其实就是对List进行操作
    /// </summary>
    /// <typeparam name="K">键的泛型</typeparam>
    /// <typeparam name="V">值的泛型</typeparam>
    class MyDictionary<K, V>
    {
        MyList<K> keys;
        MyList<V> values;

        public MyDictionary()
        {
            keys = new MyList<K>(10);
            values = new MyList<V>(10);
        }
        /// <summary>
        /// 在键的list和值的list中对应下标的添加键和值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {            
            if (ContainsKey(key))
            {
                throw new Exception("不能添加相同的键");
            }
            else
            {
                keys.Add(key);
                values.Add(value);
            }

        }
        /// <summary>
        /// 字典中的键值对的数目
        /// </summary>
        public int Count
        {
            get
            {
                return this.keys.Count;
            }
        }
        /// <summary>
        /// 清空字典中的键值对，但保留位置
        /// </summary>
        public void Clear()
        {
            this.keys.Clear();
            this.values.Clear();
        }
        /// <summary>
        /// 判断字典中是否含有指定的键
        /// </summary>
        /// <param name="key">指定的键</param>
        /// <returns></returns>
        public bool ContainsKey(K key)
        {            
            return this.keys.Contanis(key);
        }
        /// <summary>
        /// 
        /// 判断字典中是否含有指定的值
        /// </summary>
        /// <param name="value">指定的值</param>
        /// <returns></returns>
        public bool ContainsValue(V value)
        {            
            return this.values.Contanis(value);
        }
        /// <summary>
        /// 移除指定键对应的键值对
        /// </summary>
        /// <param name="key">指定键</param>
        /// <returns></returns>
        public V Remove(K key)
        {
            if (ContainsKey(key))
            {
                this.keys.Remove(key);
                this.values.RemoveAt(keys.IndexOf(key));
                return this.values[keys.IndexOf(key)];
            }
            else
            {
                throw new Exception("不存在该键");
            }
        }
        /// <summary>
        /// 返回指定键的值  使用: 对象[key]
        /// </summary>
        /// <param name="key">指定键</param>
        /// <returns></returns>        
        public V this[K key]
        {
            get
            {
                if (ContainsKey(key))
                {
                    return this.values[keys.IndexOf(key)];
                }
                else
                {
                    throw new Exception("不存在此键");
                }                
            }
            set
            {
                //可以将指定键位的值进行修改
                this.values[keys.IndexOf(key)] = value;
            }
        }
        /// <summary>
        /// 返回字典中的值的集合
        /// </summary>
        /// <returns></returns>
        public MyList<V> Values()
        {           
            return this.values;
        }
        /// <summary>
        /// 返回字典中的键的集合
        /// </summary>
        /// <returns></returns>
        public MyList<K> Keys()
        {
            return this.keys;
        }

    }
}
