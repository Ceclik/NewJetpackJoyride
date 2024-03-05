using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenuScripts
{
    public class MainMenuHandler : MonoBehaviour
    {
        [SerializeField] private Text highscoreText;

        private void Start()
        {
            highscoreText.text = $"Highscore: {PlayerPrefs.GetInt("Highscore", 0)}";
        }

        public void OnPlayButtonClick()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
