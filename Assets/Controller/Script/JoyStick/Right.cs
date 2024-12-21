using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Right : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public int checkLeftRight;


    private void Start()
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        
        checkLeftRight = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        checkLeftRight = 0;
    }
}
