using EnergyBarrierScripts;
using GravitySwitcherScripts;
using RocketScripts;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class InjuriesPicker : MonoBehaviour
    {
        private Player _player;
        private GravitySwitcher _gravitySwitcher;
        private Animator _animator;

        [SerializeField] private GameObject fuelBackground;
        [SerializeField] private GameObject gravityModeIndicator;

        private void Start()
        {
            fuelBackground.SetActive(true);
            gravityModeIndicator.SetActive(false);
            _animator = GetComponent<Animator>();
            _player = GetComponent<Player>();
            _gravitySwitcher = GetComponent<GravitySwitcher>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<EnergyBarrierMover>(out EnergyBarrierMover mover) && _gravitySwitcher.IsInGravityMode)
            {
                _gravitySwitcher.IsInGravityMode = false;
                _animator.SetTrigger("Stop");
                _gravitySwitcher.SetNormalGravity();
                fuelBackground.SetActive(true);
                gravityModeIndicator.SetActive(false);
                mover.gameObject.SetActive(false);
            }
            else if(other.TryGetComponent<RocketMover>(out RocketMover rMover) && _gravitySwitcher.IsInGravityMode)
            {
                _gravitySwitcher.IsInGravityMode = false;
                _animator.SetTrigger("Stop");
                _gravitySwitcher.SetNormalGravity();
                fuelBackground.SetActive(true);
                gravityModeIndicator.SetActive(false);
                rMover.gameObject.SetActive(false);
            }
            else if (other.TryGetComponent<EnergyBarrierMover>(out EnergyBarrierMover Mover) && 
                     !_gravitySwitcher.IsInGravityMode)
            {
                Mover.gameObject.SetActive(false);
                _player.IsAlive = false;
            }
            else if (other.TryGetComponent<RocketMover>(out RocketMover RMover) && !_gravitySwitcher.IsInGravityMode)
            {
                RMover.gameObject.SetActive(false);
                _player.IsAlive = false;
            }
        
            if (other.TryGetComponent<GravitySwitcherDestroyer>(out GravitySwitcherDestroyer sdDestroyer))
            {
                sdDestroyer.DestroyGravitySwitcher();
                _gravitySwitcher.IsInGravityMode = true;
                fuelBackground.SetActive(false);
                gravityModeIndicator.SetActive(true);
            }
        }
    }

}
