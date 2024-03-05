using System.Collections;
using UnityEngine;

namespace CoinsScripts
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] coinsFigurePrefabs;
        [SerializeField] private LevelSpeedController speedController;
        
        private void Start()
        {
            StartCoroutine(CoinsFigureSpawner());
        }

        private IEnumerator CoinsFigureSpawner()
        {
            while (true)
            {
                yield return new WaitForSeconds(speedController.GetDeltaCoinsSpawnTime());
                float ySpawnPosition = Random.Range(-2.7f, 2.27f);
                int figureIndex = Random.Range(0, coinsFigurePrefabs.Length);
                coinsFigurePrefabs[figureIndex].transform.position = new Vector3(10.0f, ySpawnPosition, 0.0f);
                coinsFigurePrefabs[figureIndex].SetActive(true);
                for(int i = 0; i < coinsFigurePrefabs[figureIndex].transform.childCount; i++)
                    coinsFigurePrefabs[figureIndex].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
