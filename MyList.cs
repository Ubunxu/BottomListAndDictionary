using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAndDic0710_1
{
    class MyList<T>
    {
        private T[] arr;
        private int myIndex = 0;//数组中实际含有元素的个数-1（代表最后一个元素的下标）
        private int arrLen = 0;//数组的长度大小
        public MyList(int leng = 10)
        {
            arr = new T[leng];
            this.arrLen = leng;
        }
        /// <summary>
        /// 往数组的myindex后面添加value
        /// </summary>
        /// <param name="value">添加的值</param>
        public void Add(T value)
        {
            //判断是否有空位
            if (this.Count == arrLen)
            {
                this.arrLen *= 2;
                T[] newArr = new T[this.arrLen];
                for(int i = 0; i < this.arr.Length; ++i)
                {
                    newArr[i] = arr[i];
                }
                newArr[myIndex] = value;
                arr = newArr;
            }
            else
            {
                arr[myIndex] = value;
            }
            myIndex++;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">添加的值</param>
        /// <param name="index">要添加的下标</param>
        public void Insert(T value, int index)
        {
            if (index > this.myIndex || index < 0)
            {
                throw new Exception("下标越界");
            }
            else if (index >= 0 && index <= this.myIndex)
            {

                if (this.Count >= this.arrLen)
                {
                    this.arrLen += 1;
                }
                T[] newArr = new T[this.Count + 1];
                int i = 0;
                for (; i < index; ++i)
                {
                    newArr[i] = this.arr[i];
                }
                newArr[i] = value;
                for (; i <= this.myIndex; ++i)
                {
                    newArr[i + 1] = this.arr[i];
                }
                this.arr = newArr;
                ++this.myIndex;                
                
            }
        }
        public T Get(int index)
        {
            return this.arr[index];
        }
        /// <summary>
        /// 直接通过对象list[index]，就可以得到集合中的index位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return this.arr[index];
            }
            set
            {
                this.arr[index] = value;
            }
        }

        /// <summary>
        /// 移除指定值
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            RemoveAt(IndexOf(value));
        }
        /// <summary>
        /// 移除指定下标的值
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            //如果index 大于最后数组元素下标
            if (index > myIndex)
            {
                throw new Exception("下标越界");
            }
            else
            {
                myIndex--;
                T[] newArr = new T[myIndex];
                int i = 0;
                for (; i < index; ++i)
                {
                    newArr[i] = arr[i];
                }
                for(; i <= myIndex; ++i)
                {
                    newArr[i]=arr[i+1];
                }
                arr = newArr;
            }
        }

        /// <summary>
        /// 清空数组的元素，指的是将原来的元素清空，但不是将位置也移除
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < this.myIndex; ++i)
            {
                arr[i] = default(T);
            }
            this.myIndex = 0;
        }
        /// <summary>
        /// 该数组含有元素的个数
        /// </summary>
        public int Count
        {
            get { return this.myIndex+1; }
        }
        /// <summary>
        /// 从数组的第一个元素开始，查询指定值value
        ///，如果找到就方法该值对应的下标，否则返回-1
        /// </summary>
        /// <param name="value">指定查找的值</param>
        /// <returns></returns>
        public int IndexOf(T value)
        {
            for(int i = 0; i <= myIndex; ++i)
            {
                if (arr[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 从数组的最后一个元素开始往前查找，查到返回对应
        /// 下标，否则返回-1
        /// </summary>
        /// <param name="value">指定查找的值</param>
        /// <returns></returns>
        public int LastIndexOf(T value)
        {
            for(int i = myIndex; i >= 0; --i)
            {
                if (arr[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 判断指定的值是否在数组中
        /// </summary>
        /// <param name="value">指定值</param>
        /// <returns></returns>
        public bool Contanis(T value)
        {
            for(int i = 0; i <= myIndex; ++i)
            {
                if (arr[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 将数组中的元素复制到另外一个数组中
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] newArr = new T[myIndex];
            for(int i = 0; i <= myIndex; ++i)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }
    }
}
