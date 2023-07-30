using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem inventorySystem;
    public List<Item> inventory;
    public bool inventoryEnabled = false;
    public GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        if(inventorySystem == null){
            inventorySystem = this;
        } else {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            inventoryEnabled = !inventoryEnabled;
        }

        if(inventoryEnabled){
            inventoryUI.SetActive(true);
        } else {
            inventoryUI.SetActive(false);
        }
    }

    public void addItem(Item item){
        inventory.Add(item);
    }

    public void removeItem(Item item){
        inventory.Remove(item);
    }

    public void useItem(Item item){
        if(inventory.Contains(item))  {
            item.Use();
        }
    }
    /// <summary>
    /// Spawns the prefab of a item if the player want to drop a item
    /// </summary>
    /// <param name="item"></param>
    public void dropItem(Item item){

        //Check if item is droppable (is a weapon)
        //If so spawn the prefab a the position of the player
        
    }
}
