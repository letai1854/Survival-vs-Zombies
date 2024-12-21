using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Star : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {

    }
    public void UpdateTextPoint(int points)
    {
        text.text = points.ToString();
    }

}
