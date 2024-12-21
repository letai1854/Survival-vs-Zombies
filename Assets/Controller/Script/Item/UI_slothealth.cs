using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_slothealth : UI_Slot, IPointerDownHandler, IPointerUpHandler
{

    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {

    }


    public void OnPointerDown(PointerEventData eventData)
    {

        if(ManagerSkill.instance.player.maxHealth < ManagerInventory.instance.healthPlayer.currentHealth)
        {
            ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.energy);
            ManagerInventory.instance.inventory.RemoveItem((Inventory.ItemType)Type);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}

