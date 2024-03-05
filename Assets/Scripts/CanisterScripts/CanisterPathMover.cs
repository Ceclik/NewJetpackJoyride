using PlayerScripts;
using UnityEngine;

namespace CanisterScripts
{
    public class CanisterPathMover : MonoBehaviour
    {
        [SerializeField] private Transform path;
        [SerializeField] private Player player;
        [SerializeField] private LevelSpeedController speedController;
        private Transform[] _points;
        private int _currentPoint;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _currentPoint = 0;
            _points = new Transform[path.childCount];
            for (int i = 0; i < path.childCount; i++)
                _points[i] = path.GetChild(i);
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity =
                !player.IsAlive ? Vector2.zero : new Vector2(-speedController.GetLevelSpeed() - 2.5f, 0.0f);
            transform.position =
                Vector3.MoveTowards(transform.position, _points[_currentPoint].position, 2 * Time.deltaTime);
            if (transform.position == _points[_currentPoint].position)
                _currentPoint++;
            if (_currentPoint == _points.Length)
                _currentPoint = 0;
            
        }
    }
}
