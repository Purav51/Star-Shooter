using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "NewWaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject [] enemyPrefab;
    [SerializeField] Transform pathprefab;
    [SerializeField] float enemyMoveSpeed = 5f;
    [SerializeField] float TimeBetweenEnemySpawn = 1f;
    [SerializeField] float EnemySpawnVariants = 0f;
    [SerializeField] float MinSpawnTime = 0.2f;

    public Transform GetStartingWayPoints()
    {
        return pathprefab.GetChild(0);
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform [] GetWayPoints()
    {
        Transform [] waypoints = new Transform[pathprefab.childCount];
        for (int i = 0; i < pathprefab.childCount; i++)
        {
            waypoints[i] = pathprefab.GetChild(i);
        }
        return waypoints;
    }
    public int GetEnemyCount()
    {
        return enemyPrefab.Length;
    } 
    public GameObject GetenemyPrefabIndex(int index)
    {
        
        return enemyPrefab[index];
    }
    public float GetRandEnemySpawnTime()
    {
        float spawnTime = Random.Range(TimeBetweenEnemySpawn - EnemySpawnVariants, 
            TimeBetweenEnemySpawn + EnemySpawnVariants);
        spawnTime = Mathf.Clamp(spawnTime, MinSpawnTime, float.MaxValue);
        return spawnTime;
    }
}
