using System.Collections;
using ObjectPool;
using UnityEngine;

namespace RocketScripts
{
    [RequireComponent(typeof(Pool))]
    public class RocketSpawner : MonoBehaviour
    {
        [SerializeField] private LevelSpeedController speedController;

        private Pool _pool;

        private void Start()
        {
            _pool = GetComponent<Pool>();
            StartCoroutine(RocketsSpawner());
        }

        private IEnumerator RocketsSpawner()
        {
            while (true)
            {
                yield return new WaitForSeconds(speedController.GetDeltaRocketSpawnTime());
                var ySpawnPosition = Random.Range(-3.4f, 4.5f);
                _pool.GetFreeElement(new Vector3(8.3f, ySpawnPosition, 0.0f),
                    Quaternion.Euler(0.0f, 0.0f, 90.0f));
            }
        }
    }
}