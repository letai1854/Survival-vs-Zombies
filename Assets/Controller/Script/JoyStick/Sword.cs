using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sword : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public bool checkSword = false;
    public void OnDrag(PointerEventData eventData)
    {
        checkSword = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        checkSword = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        checkSword = false;
    }
}