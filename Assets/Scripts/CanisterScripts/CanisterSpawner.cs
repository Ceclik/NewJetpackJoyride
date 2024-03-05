using System;
using System.Collections;
using UnityEngine;

namespace CanisterScripts
{
    public class CanisterSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject path;
        [SerializeField] private GameObject canister;
        [SerializeField] private LevelSpeedController speedController;
        
        private void Start()
        {
            StartCoroutine(Spawner());
        }

        private IEnumerator Spawner()
        {
            while (true)
            {
                yield return new WaitForSeconds(speedController.GetDeltaCanisterSpawnTime());
                canister.SetActive(true);
                path.SetActive(true);
                canister.transform.position = new Vector3(9.5f, 0.0f, 0.0f);
                path.transform.position = new Vector3(9.5f, 0.0f, 0.0f);
            }
        }
    }
}
