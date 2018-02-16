using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Sprite m_CardBeforeFlip;
    public Sprite m_CardAfterFlip;
    public static Sprite m_SummyBeforeFlip;
    public static Sprite m_SummyAfterFlip;
    public static GameObject m_Card1;
    public static GameObject m_Card2;
    private bool isFirstCardChosen;
    private bool isSecondCardChosen;
    private bool isFirstCardFliped;
    private bool isSecondCardFliped;
    private bool isTurnCardTime;
    private bool isCardShowen;
    private int m_IndexOfRotation;
    private int m_NumberOdMatches;
    private Object thisLock = new Object();

    public UnityEvent levelEnd;

    // Use this for initialization
    void Start()
    {
        m_NumberOdMatches = 0;
        isFirstCardChosen = false;
        isSecondCardChosen = false;
        isFirstCardFliped = false;
        isSecondCardFliped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstCardFliped && isSecondCardFliped)
        {
            isFirstCardFliped = false;
            isSecondCardFliped = false;

            lock (thisLock)
            {
                if (checkSpritesEquivalation(m_Card1, m_Card2))
                {
                    m_NumberOdMatches++;
                }
            }

            if (!checkSpritesEquivalation(m_Card1, m_Card2))
            {
                isCardShowen = false;

                StartCoroutine(waitWhenNotEqual());
            }

            isFirstCardChosen = false;
            isSecondCardChosen = false;
        }

        if (m_NumberOdMatches == 5)
        {
            m_NumberOdMatches++;
            StartCoroutine(endLevel());
        }
    }

    private IEnumerator endLevel()
    {
        yield return new WaitForSeconds(2f);
        Button[] buttons = GameObject.Find("Canvas").GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons)
        {
            button.GetComponent<Button>().gameObject.SetActive(false);
        }

        levelEnd.Invoke();
    }

    private IEnumerator waitWhenNotEqual()
    {
        setButtons(false);
        yield return new WaitForSeconds(2f);
        proRotateGameObject2(m_Card1, m_Card2);
    }

    private void setButtons(bool i_ButtonEnabled)
    {
        Button[] buttons = GameObject.Find("Canvas").GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons)
        {
            button.GetComponent<Button>().enabled = i_ButtonEnabled;
        }
    }

    private bool checkSpritesEquivalation(GameObject i_Card1, GameObject i_Card2)
    {
        return i_Card1.GetComponent<Image>().sprite.name == i_Card2.GetComponent<Image>().sprite.name;
    }

    public void HandleCardClicked(GameObject i_GameObject)
    {
        setButtons(false);
        isCardShowen = true;

        if (!isFirstCardChosen)
        {
            lock (thisLock)
            {
                isFirstCardChosen = true;
            }

            m_Card1 = i_GameObject;

            proRotateGameObject(i_GameObject);
        }
        else
        {
            lock (thisLock)
            {
                isSecondCardChosen = true;
            }

            m_Card2 = i_GameObject;

            proRotateGameObject(i_GameObject);
        }
    }

    private void setChosenCard()
    {
        if (!isFirstCardChosen)
        {
            isFirstCardChosen = true;
        }
        else
        {
            isSecondCardChosen = true;
        }
    }

    private void proRotateGameObject(GameObject i_GameObject)
    {
        isTurnCardTime = true;
        m_IndexOfRotation = 18;

        rotateGameObject(9, i_GameObject);
    }

    private void rotateGameObject(int minIndex, GameObject i_GameObject)
    {
        if (m_IndexOfRotation == 0)
        {
            if (!isFirstCardFliped)
            {
                isFirstCardFliped = true;
            }
            else
            {
                isSecondCardFliped = true;
            }

            setButtons(true);
        }

        if (m_IndexOfRotation > minIndex)
        {
            m_IndexOfRotation--;
            i_GameObject.transform.eulerAngles = new Vector3(i_GameObject.transform.eulerAngles.x,
            i_GameObject.transform.eulerAngles.y + 10, i_GameObject.transform.eulerAngles.z);
            StartCoroutine(wait(0.05f, minIndex, i_GameObject));
        }
        else
        {
            if (isTurnCardTime)
            {
                i_GameObject.GetComponent<Image>().sprite = (isCardShowen) ? m_SummyAfterFlip : m_CardAfterFlip;
                isCardShowen = !isCardShowen;
                isTurnCardTime = false;
                rotateGameObject(0, i_GameObject);
            }
        }
    }

    private IEnumerator wait(float waitTime, int minIndex, GameObject i_GameObject)
    {
        yield return new WaitForSeconds(waitTime);
        rotateGameObject(minIndex, i_GameObject);
    }

    private void proRotateGameObject2(GameObject i_GameObject1, GameObject i_GameObject2)
    {
        isTurnCardTime = true;
        m_IndexOfRotation = 18;

        rotateGameObject2(9, i_GameObject1, i_GameObject2);
    }

    private void rotateGameObject2(int minIndex, GameObject i_GameObject1, GameObject i_GameObject2)
    {
        if (m_IndexOfRotation == 0)
        {
            setButtons(true);
        }

        if (m_IndexOfRotation > minIndex)
        {
            m_IndexOfRotation--;

            i_GameObject1.transform.eulerAngles = new Vector3(i_GameObject1.transform.eulerAngles.x,
            i_GameObject1.transform.eulerAngles.y + 10, i_GameObject1.transform.eulerAngles.z);
            i_GameObject2.transform.eulerAngles = new Vector3(i_GameObject2.transform.eulerAngles.x,
            i_GameObject2.transform.eulerAngles.y + 10, i_GameObject2.transform.eulerAngles.z);

            StartCoroutine(wait2(0.05f, minIndex, i_GameObject1, i_GameObject2));
        }
        else
        {
            if (isTurnCardTime)
            {
                i_GameObject1.GetComponent<Image>().sprite = (isCardShowen) ? m_SummyAfterFlip : m_CardBeforeFlip;
                i_GameObject2.GetComponent<Image>().sprite = (isCardShowen) ? m_SummyAfterFlip : m_CardBeforeFlip;
                isCardShowen = !isCardShowen;
                isTurnCardTime = false;
                rotateGameObject2(0, i_GameObject1, i_GameObject2);
            }
        }
    }

    private IEnumerator wait2(float waitTime, int minIndex, GameObject i_GameObject1, GameObject i_GameObject2)
    {
        yield return new WaitForSeconds(waitTime);
        rotateGameObject2(minIndex, i_GameObject1, i_GameObject2);
    }


    public void HandleReplyButtonClicked()
    {
        Debug.Log("click");
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HandleLevelsButtonClicked()
    {
        Debug.Log("click");
        Application.LoadLevel("Levels");
        //SceneManager.LoadScene("Levels", LoadSceneMode.Additive);
    }
}