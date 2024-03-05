using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class ScoreCounter : MonoBehaviour
    {
        public int Score { get; private set; }
        private Player _player;
        [SerializeField] private float deltaIncreaseScoreTime;
        [SerializeField] private Text scoreText;
        

        private void Start()
        {
            Score = 0;
            _player = GetComponent<Player>();
            StartCoroutine(ScoreAdder());
        }

        private IEnumerator ScoreAdder()
        {
            while (_player.IsAlive)
            {
                yield return new WaitForSeconds(deltaIncreaseScoreTime);
                Score++;
                scoreText.text = $"Score: {Score}";
            }
        }
    }
}
