using PlayerScripts;
using UnityEngine;

namespace CanisterScripts
{
    public class PathMover : MonoBehaviour
    {
        [SerializeField] private LevelSpeedController speedController;
        [SerializeField] private Player player;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity =
                !player.IsAlive ? Vector2.zero : new Vector2(-speedController.GetLevelSpeed() - 2.5f, 0.0f);
        }
    }
}
