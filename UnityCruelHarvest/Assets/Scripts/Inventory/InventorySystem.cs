using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    
    public List<Item> itemInventory;
    public int itemInventorySize = 20;
    public List<Item> toolInventory;
    public int toolInventorySize = 3;
    public bool inventoryEnabled = false;
    public GameObject inventoryUI;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    

    #region Singleton

    public static InventorySystem instance;

    void Awake()
    {
        if(instance != null){
            instance = this;
        } else {
            Debug.LogWarning("There is already a InventorySystem in the scene");
            return;
        }
    }

    #endregion

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

    /// <summary>
    /// Adds item to inventory if there is space.
    /// Items of the type Tool will be added to the toolInventory
    /// Items of the type Consumable will be added to the itemInventory
    /// </summary>
    /// <param name="item"> Item that is added</param>
    /// <returns>True if adding the item was succesful</returns>
    public bool addItem(Item item){
        if(item.type == Item.ItemType.Tool) {
            if(toolInventory.Count < toolInventorySize) {

                
                toolInventory.Add(item);
                if (onItemChangedCallback != null) {
                    onItemChangedCallback.Invoke();
                }
                return true;
            } else {
                return false;
            }
            
            
        } else {
            if(itemInventory.Count < itemInventorySize) {
                itemInventory.Add(item);
                if (onItemChangedCallback != null) {
                    onItemChangedCallback.Invoke();
                }
                return true;
            } else {
                return false;
            }
            
        }
    }
    /// <summary>
    /// Removes item from inventory
    /// </summary>
    /// <param name="item">Ithem that should be removed</param>
    public void removeItem(Item item){
        if(item.type == Item.ItemType.Tool) {
            toolInventory.Remove(item);
        } else {
            itemInventory.Remove(item);
        }
        if (onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
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
