using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public bool checkFight = false;
    

    public void OnDrag(PointerEventData eventData)
    {
        checkFight = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        checkFight = true;
      
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        checkFight = false;
    }
}
