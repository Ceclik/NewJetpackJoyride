using ObjectPool;
using UnityEngine;

namespace RocketScripts
{
    [RequireComponent(typeof(PoolObject))]
    public class RocketDestroyer : MonoBehaviour
    {
        private PoolObject _poolObject;

        private void Start()
        {
            _poolObject = GetComponent<PoolObject>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.name.Equals("EnemyDestroyer"))
                _poolObject.ReturnToPool();
        }
    }
}

