using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "NewWaveConfig")]
public class WaveConfigSO : ScriptableObject
{
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
}
