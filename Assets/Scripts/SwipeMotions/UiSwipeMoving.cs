using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiSwipeMoving : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform Player;
   

    private void Start()
    {//Debug.Log("swipe");
      
    }

    public void OnBeginDrag(PointerEventData eventData)
    { 
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
           
            if (eventData.delta.x > 0)
            {
                Player.position += Vector3.right;
               // Debug.Log("right");
            }
            else
            {
                Player.position += Vector3.left;
              //  Debug.Log("left");
            }

        }
        else 
        {
            if (eventData.delta.y > 0)
            {
                Player.position += Vector3.up;
               // Debug.Log("up");
            }
            else
            {
                Player.position += Vector3.down;
                //Debug.Log("down");
            }
        } 
    }

    public void OnDrag(PointerEventData eventData)   {}
}
