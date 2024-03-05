using UnityEngine;

namespace PlayerScripts
{
    public class GravitySwitcher : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        public bool IsInGravityMode { get; set; }
        public bool IsGravitySwitched { get; private set; }

        private float _normalGravity;

        private void Start()
        {
            IsInGravityMode = false;
            IsGravitySwitched = false;
            _rigidbody = GetComponent<Rigidbody2D>();
            _normalGravity = _rigidbody.gravityScale;
        }

        public void SwitchGravity()
        {
            Debug.Log("Gravity switched!");
            IsGravitySwitched = !IsGravitySwitched;
            _rigidbody.gravityScale = -_rigidbody.gravityScale;
        }

        public void SetNormalGravity()
        {
            _rigidbody.gravityScale = _normalGravity;
        }
    }
}
