using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {

    public List<Transform> waypoints;
    public float speed;

    private int currentWaypoint = 0;
    // Use this for initialization
    void Start () {
        waypoints[0].LookAt(transform.position);
        for (int i = 1; i < waypoints.Count; i++)
        {
            waypoints[i].LookAt(waypoints[i - 1].transform.position);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (waypoints.Count != 0)
        {
            float step = speed * Time.deltaTime;
            Vector3 moveVector = Vector3.Normalize(transform.position - waypoints[currentWaypoint].transform.position);
            transform.position = transform.position - moveVector * step;
        }
    }

    public Vector3 GetMovementVector()
    {
        Vector3 moveVector = Vector3.zero;
        if (waypoints.Count != 0)
            moveVector = Vector3.Normalize(transform.position - waypoints[currentWaypoint].transform.position);
        return moveVector;
    }

    public void NextWayPoint()
    {
        currentWaypoint++;

        if (currentWaypoint >= waypoints.Count)
            currentWaypoint = 0;

    }
}
