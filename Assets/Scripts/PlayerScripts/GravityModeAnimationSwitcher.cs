using System;
using UnityEngine;

namespace PlayerScripts
{
    public class GravityModeAnimationSwitcher : MonoBehaviour
    {
        private GravitySwitcher _gravitySwitcher;
        private Animator _animator;

        private void Start()
        {
            _gravitySwitcher = GetComponent<GravitySwitcher>();
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.name.Equals("Floor") && _gravitySwitcher.IsInGravityMode)
                _animator.ResetTrigger("Running");
            if (other.gameObject.name.Equals("Ceiling") && _gravitySwitcher.IsInGravityMode)
                _animator.ResetTrigger("WrongRunning");
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name.Equals("Ceiling") && _gravitySwitcher.IsInGravityMode)
            {
                _animator.ResetTrigger("WrongGravity");
                _animator.SetTrigger("WrongRunning");
            }

            if (other.gameObject.name.Equals("Floor") && _gravitySwitcher.IsInGravityMode)
            {
                _animator.ResetTrigger("RightGravity");
                _animator.SetTrigger("Running");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _gravitySwitcher.IsInGravityMode &&
                !_gravitySwitcher.IsGravitySwitched)
            {
                Debug.Log("To wrong!");
                _animator.SetTrigger("WrongGravity");
                _gravitySwitcher.SwitchGravity();
            }

            else if (Input.GetKeyDown(KeyCode.Space) && _gravitySwitcher.IsInGravityMode &&
                _gravitySwitcher.IsGravitySwitched)
            {
                Debug.Log("To right");
                _animator.SetTrigger("RightGravity");
                _gravitySwitcher.SwitchGravity();
            }
        }
    }
}
