using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private PoolObject prefab;
        [Space(10)] [SerializeField] private Transform container; //parent of other created objects
        [SerializeField] private int minCapacity;
        [SerializeField] private int maxCapacity;
        [Space(10)] [SerializeField] private bool autoExpand; //if i don't want to have max value of objects

        private List<PoolObject> _pool;
        
        private void OnValidate()
        {
            if(autoExpand)
                maxCapacity = Int32.MaxValue;
        }

        private void Start()
        {
            CreatePool();
        }

        private void CreatePool()
        {
            _pool = new List<PoolObject>(minCapacity);
            for (int i = 0; i < minCapacity; i++)
                CreateElement();
        }

        private PoolObject CreateElement(bool isActiveByDefault = false)
        {
            var createdObject = Instantiate(prefab, container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            
            _pool.Add(createdObject);

            return createdObject;
        }

        public bool TryGetElement(out PoolObject element)
        {
            foreach (var item in _pool)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    element = item;
                    item.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public PoolObject GetFreeElement(Vector3 position)
        {
            var element = GetFreeElement();
            element.transform.position = position;
            return element;
        }

        public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
        {
            var element = GetFreeElement(position);
            element.transform.rotation = rotation;
            return element;
        }

        public PoolObject GetFreeElement()
        {
            if (TryGetElement(out var element))
                return element;

            if (autoExpand)
                return CreateElement(true);
            
            if(_pool.Count < maxCapacity)
                return CreateElement(true);

            throw new Exception("Pool is empty!");
        }
    }
}
