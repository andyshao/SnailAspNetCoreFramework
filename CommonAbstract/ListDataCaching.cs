﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonAbstract
{
    public class ListDataCaching<TKey, TValue> : IListDataCaching<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _keyValuePairs;
        private Func<Dictionary<TKey, TValue>> _loadAllFunc;
        private Func<TKey, TValue> _getSingleFunc;
        public Dictionary<TKey, TValue> KeyValuePairs => _keyValuePairs;
        public List<TValue> Values => _keyValuePairs.Values.ToList();//对外只读，这是只读属性
        
        public ListDataCaching()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public TValue this[TKey i]=>_keyValuePairs[i];//这是只读索引的快捷写法，参考：https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/indexers/index
        public ListDataCaching(Func<Dictionary<TKey, TValue>> loadAllFunc, Func<TKey, TValue> getSingleFunc)
        {
            _loadAllFunc = loadAllFunc;
            _getSingleFunc = getSingleFunc;
            _keyValuePairs = _loadAllFunc();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void Refresh()
        {
            _keyValuePairs = _loadAllFunc();
        }

        /// <summary>
        /// 增加或更新对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddOrUpdate(TKey key, TValue value)
        {
            _keyValuePairs.Remove(key);
            _keyValuePairs.Add(key, value);
        }

        /// <summary>
        /// 根据对象的key，增加或更新对象
        /// </summary>
        /// <param name="key"></param>
        public void AddOrUpdate(TKey key)
        {
            _keyValuePairs.Remove(key);
            _keyValuePairs.Add(key,_getSingleFunc(key));
        }

        public void Remove(TKey key)
        {
            _keyValuePairs.Remove(key);
        }

    }
}