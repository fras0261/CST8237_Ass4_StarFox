using UnityEngine;
using System.Collections;

public class PathNode : MonoBehaviour {

    public bool isActive;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "WorldMap")
        {
            if (isActive && (col.tag == "Player" || col.tag == "Enemy"))
            {
                isActive = false;
                RailMovement railMovement = col.gameObject.transform.parent.transform.parent.gameObject.GetComponent<RailMovement>();

                railMovement.NextWayPoint();
            } 
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.tag != "WorldMap")
        {
            if (col.tag == "Player" || col.tag ==  "Enemy")
                isActive = true; 
        }
    }
}
