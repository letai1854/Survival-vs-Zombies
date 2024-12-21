using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemData item;
    public int stackSize=0;

    public InventoryItem(ItemData data)
    {
        item = data;
        stackSize = 1;
    }
    public void AddStack()
    {
        stackSize++;
    }
    public void RemoveStack()
    {
        stackSize--;
    }
}
