using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {
    public GameObject pausePanel;
    public GameObject pauseBackGround;

    public bool isPaused;

	// Use this for initialization
	void Start () {
        isPaused = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isPaused)
        {
            PauseGame(true);
        }
        else
        {
            PauseGame(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        { switchPause(); }
      

            
        }

    void PauseGame (bool state)
    {
        if (state)
        {
            Time.timeScale = 0.0f; //paused
        
        }
        else
        {
            Time.timeScale = 1.0f; //resumed
          
        }
        pausePanel.SetActive(state);
        //setX=-0.15, setY=-0.1, setZ=0
        pauseBackGround.SetActive(state);
        pauseBackGround.transform.position = new Vector3(-0.15f, -0.1f, 0);


    }

    public void switchPause()
    {
        if (isPaused)
        {
            isPaused = false; //changes the value

        }
        else
        {
            isPaused = true;

        }
    }
	
    public void startNewGame()
    {
        Application.LoadLevel("Level 1");
    }

	public void exitGame()
    {
        Application.Quit();

    }

    public void newStage()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
