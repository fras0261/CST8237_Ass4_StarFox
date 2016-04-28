using UnityEngine;
using System.Collections;

public class RotateShip : MonoBehaviour {

    public static RotateShip rotateShip;

    public Transform target;
    public Transform playerTransform;
    public float rotationSpeed;

    private Quaternion _lookRotation;
    private Vector3 _direction;

	// Update is called once per frame
	void Update () {
        SlerpRotation();
	}

    private void SlerpRotation()
    {
        if (target != null || playerTransform != null)
        {
            _direction = (target.position - playerTransform.position).normalized;
            _lookRotation = Quaternion.LookRotation(_direction);
            playerTransform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);
        }    
    }
}
