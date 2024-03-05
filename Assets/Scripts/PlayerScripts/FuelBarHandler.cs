using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class FuelBarHandler : MonoBehaviour
    {
        [SerializeField] private Image fuelBar;

        private FuelHandler _fuelHandler;

        private void Start()
        {
            _fuelHandler = GetComponent<FuelHandler>();
        }

        private void Update()
        {
            fuelBar.fillAmount = _fuelHandler.AmountOfFuel / 100;
        }
    }
}
