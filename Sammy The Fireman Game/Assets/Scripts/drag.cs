using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class drag : MonoBehaviour
{
    public UnityEvent event1;    
    private Vector3 distance;
    
    void Start()
    {        
    }

    void OnMouseDown()
    {
        distance = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen.z));
        transform.position = new Vector3(pos_move.x - distance.x, pos_move.y - distance.y, pos_move.z);
    }

     void OnMouseUp()
    {
        event1.Invoke();       
    }
}