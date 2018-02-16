using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showTime : MonoBehaviour
{
    public float time; //time to the level
    public GameObject loosePanel;
    bool isLost;
    public int currentStage;



    public Text timeBar;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("currentStage", currentStage);
        loosePanel.SetActive(false);
        isLost = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLost)
        {
            time = time - Time.deltaTime;
            int time1 = (int)time;
            timeBar.text = time1.ToString();

            if (time1 == 0) //time is out, the player lost!
            {

                isLost = true;
                timeBar.text = "0";
                Application.LoadLevel("menuLooser");
                PlayerPrefs.SetInt("loosingStage", currentStage);
                looser();

            }
        }
        else {
            Time.timeScale = 0.0f;

        }

    }

    void looser() //player lost
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f; //paused}
            loosePanel.SetActive(true);

        }
    }
}