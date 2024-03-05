using System.Collections;
using PlayerScripts;
using UnityEngine;

namespace GravitySwitcherScripts
{
    public class GravitySwitcherSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject gravitySwitcher;
        [SerializeField] private LevelSpeedController speedController;
        [SerializeField] private GravitySwitcher _gravitySwitcher;

        private void Start()
        {
            StartCoroutine(Spawner());
        }

        private IEnumerator Spawner()
        {
            while (true)
            {
                yield return new WaitForSeconds(speedController.GetDeltaGravitySwitcherSpawnTime());
                if (!_gravitySwitcher.IsInGravityMode)
                {
                    float newYPosition = Random.Range(-3.3f, 4.6f);
                    gravitySwitcher.transform.position = new Vector3(9.5f, newYPosition, 0.0f);
                    gravitySwitcher.SetActive(true);
                }
            }
        }
    }
}
