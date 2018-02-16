using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCharacters : MonoBehaviour
{
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

    // Use this for initialization
    void Start()
    {
        isSummy1AtPosition = false;
        isSummy2AtPosition = false;
        isSummy3AtPosition = false;
        isSummy4AtPosition = false;
        isSummy5AtPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            Debug.Log("success");
        }
    }
}
