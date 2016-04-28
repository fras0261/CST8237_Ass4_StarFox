using UnityEngine;
using System.Collections;

public class FirePlayerLazer : MonoBehaviour {

    public GameObject laserFire;

    private float shotVelocity;
    private float impulseAmount = 30;
    private float spawnOffset = 1.5f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rigidbody = laserFire.GetComponent<Rigidbody>();
	    if(Input.GetMouseButtonDown(0) == true)
        {
            GameObject laserObject = GameObject.Instantiate(laserFire);
            
            Vector3 spawnLocation = transform.position + (transform.forward * spawnOffset);
            laserObject.transform.position = spawnLocation;           
            
            rigidbody = laserObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.forward * impulseAmount, ForceMode.Impulse);

            Destroy(laserObject, 5.0f);
        }
	}
}
