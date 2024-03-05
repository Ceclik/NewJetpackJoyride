using CanisterScripts;
using ObjectPool;
using UnityEngine;

namespace PlayerScripts
{
    public class FuelHandler : MonoBehaviour
    {
        [SerializeField] private float deltaDecreaseFuelTimeWhileFlying;
        [SerializeField] private int deltaDecreaseFuelValue;
        [Space(10)][SerializeField] private Transform jetpack;
        [SerializeField] private Pool pool;
        private float _flyingTime;
        private Player _player;
        private GravitySwitcher _gravitySwitcher;

        public float AmountOfFuel { get; private set; }

        private void Awake()
        {
            _flyingTime = 0;
            AmountOfFuel = 100;
            _player = GetComponent<Player>();
            _gravitySwitcher = GetComponent<GravitySwitcher>();
        }

        private void Update()
        {
            if (AmountOfFuel <= 0)
                _player.IsAlive = false;
            
            if (_flyingTime >= deltaDecreaseFuelTimeWhileFlying && _player.IsAlive)
            {
                AmountOfFuel -= deltaDecreaseFuelValue;
                _flyingTime = 0;
            }

            if (Input.GetKey(KeyCode.Space) && _player.IsAlive && !_gravitySwitcher.IsInGravityMode)
            {
                _flyingTime += Time.deltaTime;
                pool.GetFreeElement(jetpack.position);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<CanisterDestroyer>(out CanisterDestroyer destroyer))
            {
                destroyer.DestroyCanister();
                AmountOfFuel = 100;
            }
        }
    }
}
