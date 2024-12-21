using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{ 
    public bool checkJump = false;

    public void OnDrag(PointerEventData eventData)
    {
        checkJump = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        checkJump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        checkJump = false;
    }
}
