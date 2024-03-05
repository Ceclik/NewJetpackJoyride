using System.Collections;
using System.Security;
using UnityEngine;

public class LevelSpeedController : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    
    
    [Space(30)][SerializeField] private float levelSpeed;
    [SerializeField] private float deltaSpeedIncreaseValue;
    [SerializeField] private float deltaSpeedIncreaseTime;
    
    
    [Space(20)] [SerializeField] private float deltaEnergyBarrierSpawnTime;
    [SerializeField] private float deltaEnergyBarrierSpawnTimeDecreaseValue;
    [SerializeField] private float minDeltaEnergyBarrierSpawnTime;
    
    
    [Space(20)] [SerializeField] private float deltaRocketSpawnTime;
    [SerializeField] private float deltaRocketSpawnTimeDecreaseValue;
    [SerializeField] private float minDeltaRocketSpawnTime;
    
    [Space(5)] [SerializeField] private float rocketMovingSpeed;
    [SerializeField] private float deltaRocketSpeedIncreaseValue;
    [SerializeField] private float maxRocketSpeed;
    

    [Space(20)] [SerializeField] private float deltaCanisterSpawnTime;
    [SerializeField] private float deltaCanisterSpawnTimeIncreaseValue;
    [SerializeField] private float maxDeltaCanisterSpawnTime;
    
    
    [Space(20)] [SerializeField] private float deltaGravitySwitcherSpawnTime;
    [SerializeField] private float deltaGravitySwitcherSpawnTimeIncreaseValue;
    [SerializeField] private float maxDeltaGravitySwitcherSpawnTime;
    
    [Space(20)] [SerializeField] private float deltaCoinsSpawnTime;
    [SerializeField] private float deltaCoinsSpawnTimeIncreaseValue;
    [SerializeField] private float maxDeltaCoinsSpawnTime;

    private void Start()
    {
        StartCoroutine(SpeedIncreaser());
    }

    private IEnumerator SpeedIncreaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(deltaSpeedIncreaseTime);
            if(levelSpeed < maxSpeed)
                levelSpeed += deltaSpeedIncreaseValue;
            if(deltaEnergyBarrierSpawnTime > minDeltaEnergyBarrierSpawnTime)
                deltaEnergyBarrierSpawnTime -= deltaEnergyBarrierSpawnTimeDecreaseValue;
            if (deltaRocketSpawnTime > minDeltaRocketSpawnTime)
                deltaRocketSpawnTime -= deltaRocketSpawnTimeDecreaseValue;
            if (deltaRocketSpawnTime < maxDeltaCanisterSpawnTime)
                deltaCanisterSpawnTime += deltaCanisterSpawnTimeIncreaseValue;
            if (rocketMovingSpeed < maxRocketSpeed)
                rocketMovingSpeed += deltaRocketSpeedIncreaseValue;
            if (deltaGravitySwitcherSpawnTime < maxDeltaGravitySwitcherSpawnTime)
                deltaGravitySwitcherSpawnTime += deltaGravitySwitcherSpawnTimeIncreaseValue;
            if (deltaCoinsSpawnTime < maxDeltaCoinsSpawnTime)
                deltaCoinsSpawnTime += deltaCoinsSpawnTimeIncreaseValue;
        }
    }

    public float GetLevelSpeed()
    {
        return levelSpeed;
    }

    public float GetDeltaEnergyBarrierSpawnTime()
    {
        return deltaEnergyBarrierSpawnTime;
    }

    public float GetDeltaRocketSpawnTime()
    {
        return deltaRocketSpawnTime;
    }

    public float GetDeltaCanisterSpawnTime()
    {
        return deltaCanisterSpawnTime;
    }

    public float GetRocketMovingSpeed()
    {
        return rocketMovingSpeed;
    }

    public float GetDeltaGravitySwitcherSpawnTime()
    {
        return deltaGravitySwitcherSpawnTime;
    }

    public float GetDeltaCoinsSpawnTime()
    {
        return deltaCoinsSpawnTime;
    }
}
