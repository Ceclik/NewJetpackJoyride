using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float acceleration;
        [SerializeField] private Vector2 direction;

        private FuelHandler _fuelHandler;
        private Player _player;
        private GravitySwitcher _gravitySwitcher;

        private void Start()
        {
            _gravitySwitcher = GetComponent<GravitySwitcher>();
            _fuelHandler = GetComponent<FuelHandler>();
            _player = GetComponent<Player>();
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Space) && _fuelHandler.AmountOfFuel > 0 && _player.IsAlive && !_gravitySwitcher.IsInGravityMode)
                rb.AddForce(direction.normalized * acceleration);
            
        }
    }
}
