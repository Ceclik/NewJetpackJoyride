using UnityEngine;

namespace CanisterScripts
{
    public class CanisterDestroyer : MonoBehaviour
    {
        [SerializeField] private GameObject parent;
        public void DestroyCanister()
        {
            parent.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
