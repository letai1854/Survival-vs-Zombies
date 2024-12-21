using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public enum ItemType
    {
        Health,
        Power
    }
    [SerializeField] public UI_Slot slotPower;
    [SerializeField] public UI_Slot slotHealth;
    [SerializeField] public Dictionary<ItemData, InventoryItem> inventoryDic;

    private void Start()
    {
        inventoryDic = new Dictionary<ItemData, InventoryItem>();
        
    }

    private void Update()
    {
        
    }

    public void RemoveItem(ItemType item)
    {
        List<ItemData> keysToRemove = new List<ItemData>();

        foreach (KeyValuePair<ItemData, InventoryItem> item1 in inventoryDic)
        {
            if (item.ToString() == item1.Key.Type.ToString())
            {
                item1.Value.RemoveStack();

                

                if (item1.Key.Type.ToString() == ItemType.Power.ToString())
                {
                    ManagerInventory.instance.powerPlayer.UpdatePower(item1.Key.powerPoints);

                    slotPower.UpdateTextPoint(item1.Value.stackSize);
                    if (item1.Value.stackSize == 0)
                    {
                        keysToRemove.Add(item1.Key);
                        ManagerInventory.instance.uI_Slot_Power.gameObject.SetActive(false);
                    }
                }
                else if (item1.Key.Type.ToString() == ItemType.Health.ToString())
                {
                    ManagerInventory.instance.healthPlayer.UpdateHealth(item1.Key.healthPoints);
                    slotHealth.UpdateTextPoint(item1.Value.stackSize);
                    if (item1.Value.stackSize == 0)
                    {
                        keysToRemove.Add(item1.Key);
                        ManagerInventory.instance.uI_Slot_Health.gameObject.SetActive(false);
                    }
                }
            }
        }

        foreach (ItemData key in keysToRemove)
        {
            inventoryDic.Remove(key);
        }
    }

    public void AddItem(ItemData item)
    {

        if (inventoryDic.ContainsKey(item))
        {

            inventoryDic[item].AddStack();
            ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.item);



        }
        else
        {
            InventoryItem newItem = new InventoryItem(item);
            inventoryDic.Add(item, newItem);
            ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.item);




        }

        if (item.Type.ToString() == ItemType.Health.ToString())
            {
                ManagerInventory.instance.uI_Slot_Health.gameObject.SetActive(true);

            }
            if (item.Type.ToString() == ItemType.Power.ToString())
            {
                ManagerInventory.instance.uI_Slot_Power.gameObject.SetActive(true);

            }



        if (inventoryDic.TryGetValue(item, out InventoryItem value))
        {
          
            if (item.Type.ToString()==ItemType.Power.ToString())
            {
                slotPower.UpdateTextPoint(value.stackSize);
                Debug.Log(item.Type);
            }
            else if (item.Type.ToString() == ItemType.Health.ToString())
            {
                slotHealth.UpdateTextPoint(value.stackSize);
            }
        }

    }
}
