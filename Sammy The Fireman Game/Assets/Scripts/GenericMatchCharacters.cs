using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenericMatchCharacters : MonoBehaviour {

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite darksprite1;
    public Sprite darksprite2;
    public Sprite darksprite3;
    public Sprite darksprite4;
    public Sprite darksprite5;

    public GameObject summy1;
    public GameObject summy2;
    public GameObject summy3;
    public GameObject summy4;
    public GameObject summy5;
    public GameObject darksummy1;
    public GameObject darksummy2;
    public GameObject darksummy3;
    public GameObject darksummy4;
    public GameObject darksummy5;

    private bool isSummy1AtPosition;
    private bool isSummy2AtPosition;
    private bool isSummy3AtPosition;
    private bool isSummy4AtPosition;
    private bool isSummy5AtPosition;

    public UnityEvent endLevel;

    public Button replyButton;
    public Button levelsyButton;


    // Use this for initialization
    void Start()
    {
        replyButton.GetComponent<Button>().enabled = true;
        levelsyButton.GetComponent<Button>().enabled = true;

        replyButton.GetComponent<Button>().gameObject.SetActive(true);
        levelsyButton.GetComponent<Button>().gameObject.SetActive(true);



        //StartCoroutine(levelEnd());
        isSummy1AtPosition = false;
        isSummy2AtPosition = false;
        isSummy3AtPosition = false;
        isSummy4AtPosition = false;
        isSummy5AtPosition = false;


        summy1.GetComponent<SpriteRenderer>().sprite = sprite1;
        summy2.GetComponent<SpriteRenderer>().sprite = sprite2;
        summy3.GetComponent<SpriteRenderer>().sprite = sprite3;
        summy4.GetComponent<SpriteRenderer>().sprite = sprite4;
        summy5.GetComponent<SpriteRenderer>().sprite = sprite5;
        darksummy1.GetComponent<SpriteRenderer>().sprite = darksprite1;
        darksummy2.GetComponent<SpriteRenderer>().sprite = darksprite2;
        darksummy3.GetComponent<SpriteRenderer>().sprite = darksprite3;
        darksummy4.GetComponent<SpriteRenderer>().sprite = darksprite4;
        darksummy5.GetComponent<SpriteRenderer>().sprite = darksprite5;

    }



    private IEnumerator levelEnd()
    {
        yield return new WaitForSeconds(2f);
        endLevel.Invoke();
    }

    public void HandleSummy1Moved(GameObject i_GameObject)
    {
        HandleSummyCharacterMoved(i_GameObject, darksummy1, -3.25f, -2.85f, 2.1f, 2.6f, out isSummy1AtPosition);
    }

    public void HandleSummy2Moved(GameObject i_GameObject)
    {
        HandleSummyCharacterMoved(i_GameObject, darksummy2, -2.7f, -2.22f, -2.05f, -1.46f, out isSummy2AtPosition);
    }

    public void HandleSummy3Moved(GameObject i_GameObject)
    {
        HandleSummyCharacterMoved(i_GameObject, darksummy3, 0.3f, 1f, -2.9f, -2.2f, out isSummy3AtPosition);
    }

    public void HandleSummy4Moved(GameObject i_GameObject)
    {
        HandleSummyCharacterMoved(i_GameObject, darksummy4, 4.4f, 5f, 2.3f, 3.25f, out isSummy4AtPosition);
    }

    public void HandleSummy5Moved(GameObject i_GameObject)
    {
        HandleSummyCharacterMoved(i_GameObject, darksummy5, 1.3f, 2.05f, 2.75f, 3.7f, out isSummy5AtPosition);
    }

    private void HandleSummyCharacterMoved(GameObject i_GameObject, GameObject i_DarkGameObject, float minX, float maxX, float minY, float maxY, out bool isSummyAtPosition)
    {
        isSummyAtPosition = false;
        float positionX = i_GameObject.transform.position.x;
        float positionY = i_GameObject.transform.position.y;
        if (minX < positionX && positionX < maxX && minY < positionY && positionY < maxY)
        {
            isSummyAtPosition = true;
            i_GameObject.transform.position = new Vector3(i_DarkGameObject.transform.position.x, i_DarkGameObject.transform.position.y, 0);
            //Debug.Log(i_GameObject.name);
            i_GameObject.GetComponent<Renderer>().enabled = false;
            i_DarkGameObject.GetComponent<Renderer>().enabled = false;
        }

        if (isSummy1AtPosition & isSummy2AtPosition & isSummy3AtPosition & isSummy4AtPosition & isSummy5AtPosition)
        {
            //Debug.Log("success");
            StartCoroutine(levelEnd());
           // endLevel.Invoke();
        }
    }

    public void HandleReplyButtonClicked()
    {
        Debug.Log("click");
        Application.LoadLevel(Application.loadedLevel);        
    }

    public void HandleLevelsButtonClicked()
    {
        Debug.Log("click");
        Application.LoadLevel("Levels");        
    }
}