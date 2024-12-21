using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Slot : MonoBehaviour
{

    public TextMeshProUGUI text;
    public ItemType Type;
    protected int current = 0;
    private void Awake()
    {
    }
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
