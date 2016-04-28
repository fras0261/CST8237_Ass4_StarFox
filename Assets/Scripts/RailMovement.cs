using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// "Unity Shooter on Rails Part 1: Ship Movement": https://www.youtube.com/watch?v=TKF7d1BVE0Q
/// </summary>
public class RailMovement : MonoBehaviour {

    //public static RailMovement railMovement = null; //

    public List<Transform> waypoints;
    public float speed;

    private RotateShip rotateShip;

    private int currentWaypoint = 0;

	// Use this for initialization
	void Start () {
        //railMovement = this;

        gameObject.AddComponent<RotateShip>();
        rotateShip = gameObject.GetComponent<RotateShip>();

        waypoints[0].LookAt(transform.position);
        for(int i = 1; i < waypoints.Count; i++)
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

    /// <summary>
    /// 
    /// </summary>
    public void NextWayPoint()
    {
        currentWaypoint++;

        if (currentWaypoint >= waypoints.Count)
            currentWaypoint = 0;
  
        rotateShip.playerTransform = this.transform;
        rotateShip.target = waypoints[currentWaypoint];
        rotateShip.rotationSpeed = 2.5f;
    }
}
