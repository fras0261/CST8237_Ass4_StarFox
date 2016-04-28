using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void LoadHowTo()
    {
        SceneManager.LoadScene("Controls");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
