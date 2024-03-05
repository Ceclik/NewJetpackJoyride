using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenuScripts
{
    public class DeathMenuHandler : MonoBehaviour
    {
        private int _score;
        private int _highscore;

        [SerializeField] private Text scoreText;
        [SerializeField] private Text highscoreText;

        private void Start()
        {
            _score = PlayerPrefs.GetInt("Score", 0);
            if (_score >= PlayerPrefs.GetInt("Highscore", 0))
            {
                _highscore = _score;
                PlayerPrefs.SetInt("Highscore", _highscore);
            }
            else _highscore = PlayerPrefs.GetInt("Highscore");

            scoreText.text = $"Your score is: {_score}";
            highscoreText.text = $"Your best is: {_highscore}";
        }

        public void OnMenuButtonClick()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void OnTryAgainButtonClick()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
