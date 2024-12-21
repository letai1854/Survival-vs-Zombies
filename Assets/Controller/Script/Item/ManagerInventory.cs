using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerInventory : MonoBehaviour
{
    public static ManagerInventory instance;
    public Inventory inventory;
    public UI_Slot uI_Slot_Health;
    public UI_slotPower uI_Slot_Power;
    public UI_HealthPlayer healthPlayer;
    public UI_Power powerPlayer;
    public UI_Star star;
    
    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
