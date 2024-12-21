using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Health,
    Power
}

[CreateAssetMenu (fileName ="New data item", menuName ="Data/item")]

public class ItemData : ScriptableObject
{
    public ItemType Type;
    public string Name;
    public string Description;
    public Sprite icon;
    [Header("infor point")]
    public int healthPoints;
    public int powerPoints;

}
