using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public new string name;
    public int id;
    public string description;
    public Sprite icon;
    public ItemType type;

    
    public enum ItemType {
        Tool,
        Consumable


    }
    // Update is called once per frame
    public virtual void Use()
    {
        Debug.Log("Using item: " + name);
    }
}
