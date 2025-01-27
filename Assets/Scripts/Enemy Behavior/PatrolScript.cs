using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    //list of all the points that the enemy this script is on will move to.
    [SerializeField] List<Transform> points = new List<Transform>();
    //the point the becomes the one it moves to.
    private Transform target;
    public bool shouldFLip;

    Spider2d spider2D;

    //Number the waypoints and also specify the minimum distance the entity needs to be before it has arrived
    private int targetWaypointNumber = 0;
    private float minimumDistance = 0.1f;
    private int lastWaypointNumber;

    [SerializeField] private float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointNumber = points.Count - 1;
        target = points[targetWaypointNumber];
        spider2D = GetComponent<Spider2d>();
    }

    public void Patrol()
    {
        //how fast are we moving to each point
        float moveStep = moveSpeed * Time.deltaTime;

        //Distance between the enemy and whatever the current target is
        float Distance = Vector2.Distance(transform.position, target.position);
        CheckDistance(Distance);

        //Moving our Spider from current waypoint/position to the next one
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveStep);
    }

    void CheckDistance(float currentDistance)
    {
        //set our target to be the next waypoint in the list then change target
        if (currentDistance < minimumDistance)
        {
            targetWaypointNumber++;
            ChangeTarget();
            if (shouldFLip)
            {
                spider2D.FlipDirection();
            }
        }
    }

    void ChangeTarget()
    {
        //if finished all waypoints, restart from 0!
        if (targetWaypointNumber > lastWaypointNumber)
        {
            targetWaypointNumber = 0;
        }
        //get current target number
        target = points[targetWaypointNumber];
    }

}
