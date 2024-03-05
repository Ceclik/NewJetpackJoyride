using PlayerScripts;
using UnityEngine;

namespace BackgroundScripts
{
    public class BackgroundMover : MonoBehaviour
    {
        [SerializeField] private LevelSpeedController speedController;
        
        private Rigidbody2D _rigidbody;
        private Player _player;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _player = GameObject.Find("Player").GetComponent<Player>();
        }
        private void FixedUpdate()
        {
            _rigidbody.velocity = !_player.IsAlive ? Vector2.zero : new Vector2(-speedController.GetLevelSpeed(), 0.0f);
            if (transform.position.x <= -17.7f)
                transform.position = new Vector3(17.7f, 0.0f, 0.0f);
        }
    }
}
