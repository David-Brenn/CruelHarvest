using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public new string name;
    public int id;
    public string description;
    public Sprite icon;

    // Update is called once per frame
    public virtual void Use()
    {
        Debug.Log("Using item: " + name);
    }
}
