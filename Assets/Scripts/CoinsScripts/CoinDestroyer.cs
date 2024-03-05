using UnityEngine;

namespace CoinsScripts
{
    public class CoinDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.name.Equals("EnemyDestroyer"))
                gameObject.SetActive(false);
        }
    }
}
