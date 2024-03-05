using System.Collections;
using ObjectPool;
using PlayerScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnergyBarrierScripts
{
    public class EnergyBarrierSpawner : MonoBehaviour
    {
        [SerializeField] private LevelSpeedController speedController;
        
        [Space(10)][SerializeField] private float minScale;
        [SerializeField] private float maxScale;
        [SerializeField] private float minAngle;
        [SerializeField] private float maxAngle;
        
        [Space(10)][SerializeField] private Pool pool;

        private Player _player;

        private void Start()
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
            StartCoroutine(EnergyBarriersSpawner());
        }

        private IEnumerator EnergyBarriersSpawner()
        {
            while (_player.IsAlive)
            {
                yield return new WaitForSeconds(speedController.GetDeltaEnergyBarrierSpawnTime());
                float ySpawnPosition = Random.Range(-2.7f, 2.7f);
                float zAngle = Random.Range(minAngle, maxAngle);
                var spawnedBarrier = pool.GetFreeElement(new Vector3(9.4f, ySpawnPosition, 0.0f),
                    Quaternion.Euler(0.0f, 0.0f, zAngle));
                float scaleOfBarrier = Random.Range(minScale, maxScale);
                spawnedBarrier.transform.localScale =
                    new Vector3(scaleOfBarrier, spawnedBarrier.transform.localScale.y, 0.0f);
            }
        }
    }
}

