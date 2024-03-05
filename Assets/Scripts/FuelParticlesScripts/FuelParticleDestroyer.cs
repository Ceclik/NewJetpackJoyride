using ObjectPool;
using UnityEngine;

namespace FuelParticlesScripts
{
    public class FuelParticleDestroyer : MonoBehaviour
    {
        private PoolObject _poolObject;
        private float _aliveTime;
        private float _particleAliveTime;

        private void Start()
        {
            _poolObject = GetComponent<PoolObject>();
            _particleAliveTime = GetComponent<ParticleSystem>().startLifetime;
            _aliveTime = 0;
        }

        private void Update()
        {
            _aliveTime += Time.deltaTime;
            if (_aliveTime > _particleAliveTime)
            {
                _poolObject.ReturnToPool();
                _aliveTime = 0;
            }
        }
    }

}
