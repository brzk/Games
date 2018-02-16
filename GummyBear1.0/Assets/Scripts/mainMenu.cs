using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void start()
    {
        Application.LoadLevel("openingVideo");
        PlayerPrefs.SetInt("currentStage",0);
    }
    public void exit()
    {
        Application.Quit();
    }
}
