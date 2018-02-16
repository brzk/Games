using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void HandeleLevelButtonClicked(int i_Level)
    {
        Application.LoadLevel("Level" + i_Level);
        //SceneManager.LoadScene("Level" + i_Level, LoadSceneMode.Additive);
    }
}
