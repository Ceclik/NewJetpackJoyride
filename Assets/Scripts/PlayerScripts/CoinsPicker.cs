using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class CoinsPicker : MonoBehaviour
    {
        [SerializeField] private Text coinsText;
        
        private int _amountOfCollectedCoins;

        private void Start()
        {
            _amountOfCollectedCoins = 0;
            coinsText.text = _amountOfCollectedCoins.ToString();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name.Equals("Coin"))
            {
                _amountOfCollectedCoins++;
                other.gameObject.SetActive(false);
                coinsText.text = _amountOfCollectedCoins.ToString();
            }
        }
    }
}
