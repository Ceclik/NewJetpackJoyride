using PlayerScripts;
using UnityEngine;

namespace CoinsScripts
{
    public class CoinsMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private Player player;
        [Space(20)] [SerializeField] private LevelSpeedController speedController;

        private void FixedUpdate()
        {
            rigidbody.velocity = !player.IsAlive ? Vector2.zero : new Vector2(-speedController.GetLevelSpeed(), 0.0f);
        }
    }
}
