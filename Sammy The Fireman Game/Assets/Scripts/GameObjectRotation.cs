using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameObjectRotation : MonoBehaviour
{
    public Sprite m_SummyBeforeFlip;
    public Sprite m_SummyAfterFlip;

    public UnityEvent setChosenCardEvent;

    public void setChosenCard(GameObject i_GameObject)
    {
        LevelManager.m_SummyBeforeFlip = m_SummyBeforeFlip;
        LevelManager.m_SummyAfterFlip = m_SummyAfterFlip;

        if (LevelManager.m_Card1 == null)
        {
            LevelManager.m_Card1 = i_GameObject;
        }
        else
        {
            LevelManager.m_Card2 = i_GameObject;
        }

        setChosenCardEvent.Invoke();
    }
}
