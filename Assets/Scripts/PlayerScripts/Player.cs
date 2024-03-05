using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public bool IsAlive { get; set; }
        [SerializeField] private Animator animator;
        [SerializeField] private float deltaDeathMenuShowTime;
        private ScoreCounter _scoreCounter;
        private GravitySwitcher _gravitySwitcher;

        private void Awake()
        {
            _gravitySwitcher = GetComponent<GravitySwitcher>();
            _scoreCounter = GetComponent<ScoreCounter>();
            IsAlive = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.name.Equals("Floor") && IsAlive && !_gravitySwitcher.IsInGravityMode)
            {
                animator.SetTrigger("Flying");
                animator.ResetTrigger("Running");
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name.Equals("Floor") && IsAlive && !_gravitySwitcher.IsInGravityMode)
            {
                animator.SetTrigger("Running");
                animator.ResetTrigger("Flying");
            }
        }

        private void Update()
        {
            if (!IsAlive)
            {
                _gravitySwitcher.SetNormalGravity();
                animator.ResetTrigger("Flying");
                animator.ResetTrigger("Running");
                animator.SetTrigger("Death");
                StartCoroutine(ShowDeathMenu());
            }
        }

        private IEnumerator ShowDeathMenu()
        {
            yield return new WaitForSeconds(deltaDeathMenuShowTime);
            PlayerPrefs.SetInt("Score", _scoreCounter.Score);
            SceneManager.LoadScene("DeathMenu");
        }
    }
}
