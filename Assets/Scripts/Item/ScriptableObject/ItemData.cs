using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    SpeedBoost,
    JumpBoost,
    HealthPotion
}

[System.Serializable]
public class ItemDataConsumable
{
    public ItemType _itemType;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("info")]
    public string displayName;
    public string description;
    public ItemType type;
    public GameObject dropPrefab;
    
    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}