using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData itemData;
    private int i = 1;
    void OnValidate()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.icon;
        gameObject.name = "Item object -"+ itemData.name;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && i == 1)
        {
              ManagerInventory.instance.inventory.AddItem(itemData);
                this.transform.localScale = new Vector3(transform.localScale.x * 0.7f, transform.localScale.x * 0.7f, transform.localScale.x * 0.7f);
                this.transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.x * 0.5f, transform.localScale.x * 0.5f);
                gameObject.SetActive(false);
               i = 2;             
        }
    }
}
