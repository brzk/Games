using UnityEngine;
using System.Collections;

public class loosingMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void newStage()
    {
       int a= PlayerPrefs.GetInt("loosingStage");
        Application.LoadLevel("Level "+a);
    }

    public void newGame()
    {
        Application.LoadLevel("Level 1");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
