using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPositionManager : MonoBehaviour
{

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;

    private Button[] buttons;


    //public GameObject button1;
    //public GameObject button2;
    //public GameObject button3;
    //public GameObject button4;
    //public GameObject button5;
    //public GameObject button6;
    //public GameObject button7;
    //public GameObject button8;
    //public GameObject button9;
    //public GameObject button10;

    //private GameObject[] buttons;




    // Use this for initialization
    void Start()
    {
        buttons = new Button[] { button1, button2, button3, button4, button5
        ,button6,button7,button8,button9,button10};

        scrambleButtons();
        setButtonPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void scrambleButtons()
    {


        int buttonIndex;
        Button tempButton;

        for (int i = 0; i < 10; i++)
        {
            buttonIndex = (int)Random.Range(0f, 10f);
            tempButton = buttons[buttonIndex];
            buttons[buttonIndex] = buttons[9- i];
            buttons[9 - i] = tempButton;            
        }        
    }


    private void setButtonPosition()
    {
        float positionX = -8.4f;
        float positionY = 2.5f;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.position = new Vector3(positionX, positionY, 0);
            if (i % 2 == 1)
            {
                positionX = positionX + 4.2f;
            }

            positionY = positionY * -1;
        }
    }
}
