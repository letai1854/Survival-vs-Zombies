using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dash : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public bool checkDash = false;
    public Image image;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private Color originColor;
    public void Start()
    {
        originColor = image.color;
        textMeshProUGUI.enabled = false;
    }
    public void Update()
    {
        if (ManagerSkill.instance.player.timeDashLeft > 0)
        {
            image.color = Color.gray;
            textMeshProUGUI.enabled = true;
            textMeshProUGUI.text = Mathf.RoundToInt((ManagerSkill.instance.player.timeDashLeft)).ToString();
        }
        else
        {
            image.color = originColor;
            textMeshProUGUI.enabled = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        checkDash = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        checkDash = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        checkDash = false;
    }
}
