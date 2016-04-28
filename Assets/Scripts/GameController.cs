using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController gameController;

    public Text scoreText;
    public Text healthText;

    private const int MAX_SCORE = 999999999;

    private int _playerScore = 0;
    private int _ringPoints = 50;
    private int _enemyPoints = 100;
    private int _lives = 5;

	// Use this for initialization
	void Start () {
        gameController = this;
	}
	
	// Update is called once per frame
	void Update ()
    {	    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
	}


    public void GetRingPoints()
    {
        _playerScore += _ringPoints;
        if (_playerScore > MAX_SCORE)
            _playerScore = MAX_SCORE;
        scoreText.text = "Score: " + _playerScore.ToString("D9");
    }

    public void GetEnemyPoints()
    {
        _playerScore += _enemyPoints;     
        if (_playerScore > MAX_SCORE)
            _playerScore = MAX_SCORE;
        scoreText.text = "Score: " + _playerScore.ToString("D9");
    }
}
