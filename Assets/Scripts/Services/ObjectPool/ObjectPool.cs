using System.Collections.Generic;
using UnityEngine;

namespace Services.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private List<T> _pool;
        private T _prefab;
        private Transform _container;
        private int _initialPoolSize;

        public ObjectPool(T prefab, int initialPoolSize, Transform container = null)
        {
            _prefab = prefab;
            _container = container;
            _initialPoolSize = initialPoolSize;

            _pool = new List<T>(_initialPoolSize);

            for (int i = 0; i < _initialPoolSize; i++)
            {
                var newObject = Create();
                _pool.Add(newObject);
            }
        }

        public T Get()
        {
            foreach (var obj in _pool)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    obj.gameObject.SetActive(true);
                    return obj;
                }
            }

            var newObject = Create();
            _pool.Add(newObject);
            return newObject;
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        private T Create()
        {
            T newObject = GameObject.Instantiate(_prefab, _container);
            newObject.gameObject.SetActive(false);
            return newObject;
        }
    }
}