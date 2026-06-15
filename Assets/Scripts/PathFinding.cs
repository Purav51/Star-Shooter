using Unity.VisualScripting;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    Transform [] waypoints;
    int waypointsIndex = 0;
    void Start()
    {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waveConfig.GetStartingWayPoints().position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointsIndex < waypoints.Length)
        {
            Vector3 targetPos = waypoints[waypointsIndex].position;
            float MoveDelta = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, MoveDelta);
            if (transform.position == targetPos)
            {
                waypointsIndex++; 
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
