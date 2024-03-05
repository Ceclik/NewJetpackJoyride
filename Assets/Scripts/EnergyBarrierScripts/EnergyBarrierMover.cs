using PlayerScripts;
using UnityEngine;

namespace EnergyBarrierScripts
{
    public class EnergyBarrierMover : MonoBehaviour
    {
        private bool _isRotating;
        private Player _player;

        private Rigidbody2D _rigidbody;
        private LevelSpeedController _speedController;

        private void Start()
        {
            _isRotating = Random.Range(0, 2) != 0;
            _speedController = GameObject.Find("SpeedController").GetComponent<LevelSpeedController>();
            _player = GameObject.Find("Player").GetComponent<Player>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_isRotating)
                transform.Rotate(0, 0, 5);
            _rigidbody.velocity =
                !_player.IsAlive ? Vector2.zero : new Vector2(-_speedController.GetLevelSpeed(), 0.0f);
        }
    }
}