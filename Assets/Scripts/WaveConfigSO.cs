using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "NewWaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject [] enemyPrefab;
    [SerializeField] Transform pathprefab;
    [SerializeField] float enemyMoveSpeed = 5;

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
}
