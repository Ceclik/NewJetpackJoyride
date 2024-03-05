using UnityEngine;

namespace GravitySwitcherScripts
{
    public class GravitySwitcherDestroyer : MonoBehaviour
    {
        public void DestroyGravitySwitcher()
        {
            gameObject.SetActive(false);
        }
    }
}
