using System.Collections.Generic;

namespace CacheAssessment
{
    public class Cache<TKey, TValue>
    {
        #region Constructor

        /// <summary>
        /// Use default capacity
        /// </summary>
        public Cache() 
            : this(_capacity) { }

        /// <summary>
        /// User defined capacity
        /// </summary>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Cache(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("capacity", capacity, "Cache capacity must be positive");
            }

            _capacity = capacity;
        }

        #endregion

        #region Properties

        public TValue this[TKey key]
        {
            get => FindValue(key);
            set => UpdateOrAdd(key, value);
        }

        public int Capacity
        {
            get => _capacity;
        }

        #endregion

        #region Methods

        private static TValue FindValue(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var node = FindNode(key);

            if (node != null) return node.Value.Value;
            throw new KeyNotFoundException($"Key '{key}' not found in Cache");
        }



        private static LinkedListNode<CachePair>? FindNode(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            LinkedListNode<CachePair>? node = _cache.First;
            while (node != null)
            {
                TKey nodeKey = node.Value.Key;
                if (nodeKey != null && nodeKey.Equals(key))
                {
                    MoveNodeToFirst(node);
                    return node;
                }
                node = node.Next;
            }
            return node;
        }

        private static void UpdateOrAdd(TKey key, TValue value)
        {
            if (key  == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof (value));
            }

            var node = FindNode(key);
            if (node != null)
            {
                node.Value.Value = value;
                MoveNodeToFirst(node);
            }
            else
            {
                Add(key, value);
            }
        }

        private static void Add(TKey key, TValue value)
        {
            if (_cache.Count >= _capacity)
            {
                //CachePair removedPair = _cache.Last();
                // Log.Warn($"Cache capacity of {_capacity} has been reached. Least recently touched pair ({removePair.key}, {removePair.value}) has been evicted");
                _cache.RemoveLast();
            }

            _cache.AddFirst(new CachePair(key, value));
        }

        private static void MoveNodeToFirst(LinkedListNode<CachePair> node)
        {
            _cache.Remove(node);
            _cache.AddFirst(node);
        }

        public override string ToString()
        {
            string s = "Cache {";

            LinkedListNode<CachePair>? node = _cache.First;
            while (node != null)
            {
                CachePair pair = node.Value;
                s += $"\n  ({pair.Key}, {pair.Value})";
                node = node.Next;
            }

            s += "\n}";

            return s;
        }

        #endregion

        #region Data

        private static LinkedList<CachePair> _cache = new LinkedList<CachePair>();
        private static int _capacity = 64;

        #endregion

        #region Inner Classes

        private class CachePair
        {
            public CachePair(TKey key, TValue value)
            {
                _key = key;
                _value = value;
            }

            public TKey Key
            { 
                get => _key; 
            }

            public TValue Value 
            { 
                get => _value;
                set => _value = value;
            }

            private readonly TKey _key;
            private TValue _value;
        }

        #endregion
    }
}