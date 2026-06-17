using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] WaveConfigSO[] WaveConfigs;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        foreach (WaveConfigSO wave in WaveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetenemyPrefabIndex(i),
                currentWave.GetStartingWayPoints().position,
                Quaternion.identity,
                transform);

                yield return new WaitForSeconds(currentWave.GetRandEnemySpawnTime());
            }
            // wave ends
            yield return new WaitForSeconds(timeBetweenWaves); // wait before the start of next wave. 
        }

    }
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
