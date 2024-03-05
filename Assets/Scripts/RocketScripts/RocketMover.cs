using System;
using UnityEngine;

namespace RocketScripts
{
    public class RocketMover : MonoBehaviour
    {
        private LevelSpeedController _speedController;

        private void Awake()
        {
            _speedController = GameObject.Find("SpeedController").GetComponent<LevelSpeedController>();
        }

        private void FixedUpdate()
        {
            transform.Translate(0.0f, _speedController.GetRocketMovingSpeed() * Time.deltaTime, 0.0f);
        }
    }
}