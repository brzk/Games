using UnityEngine;
using System.Collections;


public class videoPlay : MonoBehaviour {
    private bool isActivated = false;
    public MovieTexture video;
    private int currentStage;

	// Use this for initialization
	void Start () {
        video.Play();
        isActivated = true;
        currentStage= PlayerPrefs.GetInt("currentStage");
        Debug.LogError("currentstage:" + currentStage);

    }

    IEnumerator DelayNextFunc()
    {
        yield return new WaitForSeconds(3f);
    }

    // Update is called once per frame
    void Update () {

        if (Application.loadedLevelName.Equals("mapScene6") && !video.isPlaying)
        {
            StartCoroutine(DelayNextFunc());
            Application.LoadLevel("openingMenu");
        }
        else if (Application.loadedLevelName.Equals("mapScene1")&& !video.isPlaying)
        {
            Application.LoadLevel("Level 1");
        }

    else    if (currentStage == 0 && isActivated && !video.isPlaying)
        {//isactivated=true, cuurentstage=0
            Application.LoadLevel("mapScene" + (currentStage + 1));
            isActivated = false;
           Debug.LogError("mapScene" + (currentStage + 1) + "currentstage=" + currentStage + "isactivated=" + isActivated);
            PlayerPrefs.SetInt("currentStage", 1);


            
        }

        else if(isActivated && !video.isPlaying)
        {
            Application.LoadLevel("Level "+ (currentStage+1));
            Debug.LogError("0");

        }
       

    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), video);
    }
}
