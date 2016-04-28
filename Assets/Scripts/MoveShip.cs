using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour {

    public static MoveShip moveShip;

    private float _moveSpeed = 0.1f;
    private GameController gameController;
    Animator playerAnimator;

	// Use this for initialization
	void Start ()
    {
        moveShip = this;

        playerAnimator = GetComponent<Animator>();

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            MoveUp();
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            MoveDown();

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            MoveRight();
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            MoveLeft();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnimator.SetInteger("Action", 1);
            StartCoroutine(PerformBarrelRoll());
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetInteger("Action", 2);
            StartCoroutine(PerformBarrelRoll());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void MoveUp()
    {
        bool isPastScreen = (Camera.main.WorldToScreenPoint(transform.position).y > Screen.height);
        transform.Translate(0, isPastScreen ? 0 : _moveSpeed, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    private void MoveDown()
    {
        bool isPastScreen = Camera.main.WorldToScreenPoint(transform.position).y <= 0;
        transform.Translate(0, isPastScreen ? 0 : -_moveSpeed, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    private void MoveRight()
    {
        bool isPastScreen = Camera.main.WorldToScreenPoint(transform.position).x > Screen.width;
        transform.Translate(isPastScreen ? 0 : _moveSpeed, 0, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    private void MoveLeft()
    {
        bool isPastScreen = Camera.main.WorldToScreenPoint(transform.position).x <= 0;
        transform.Translate(isPastScreen ? 0 : -_moveSpeed, 0, 0);
    }

    private IEnumerator PerformBarrelRoll()
    {
        Debug.Log("Doing a barrel roll");
        yield return new WaitForSeconds(0.33f);
        playerAnimator.SetInteger("Action", 0);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ring"))
        {
            gameController.GetRingPoints();
            Debug.Log("Hit Ring");
        }
    }
}
