using Unity.VisualScripting;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    void Start()
    {
        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetenemyPrefabIndex(i), 
            currentWave.GetStartingWayPoints().position, 
            Quaternion.identity,
            transform);
        }

    }
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
