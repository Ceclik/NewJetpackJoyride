using ObjectPool;
using UnityEngine;

namespace EnergyBarrierScripts
{
    public class EnergyBarrierDestroyer : MonoBehaviour
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

