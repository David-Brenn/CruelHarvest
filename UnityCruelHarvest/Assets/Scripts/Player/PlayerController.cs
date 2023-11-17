using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The Player Controller class is responsible for the player 's interactions with the world. 
/// </summary>
public class PlayerController : MonoBehaviour
{
    Camera cam;

    //Safes the current object the player is looking at if it is interactable
    public Interactable focus;
    private InventorySystem inventorySystem;


    public Playerhand playerhand;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        inventorySystem = InventorySystem.instance;

    }
 
    void Update()
    {

        CheckCenterForInteractable();
        NumberInput();

        
    }
    /// <summary>
    /// This method checks if the player is looking at an interactable object and if so, it sets the focus to that object.
    /// </summary>
    void CheckCenterForInteractable() {
        //Calculate the screen center
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        Ray ray = cam.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        //Cast a ray from the screen center and check if it hits an interactable object 
        if (Physics.Raycast(ray, out hit, 100)) {
            Debug.Log(hit.collider.name);
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null) {
                //Seting the focus to interact with the object
                SetFocus(interactable);

            } else {
                RemoveFocus();
            }
        }
    }

    //Sets the focus to the new interactable object and tells the object that it is focused
    void SetFocus(Interactable newFocus) {
        if(newFocus != focus){
            if(focus != null) {
                focus.OnDefocus();
            }
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus() {
        if(focus != null){
            //tell objecet that it is no longer focused
            focus.OnDefocus();     
        }
        focus = null;
        
    }

    /// <summary>
    /// This method handles the player's input of numbers, to select the items in the inventory.
    /// </summary>
    void NumberInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {

            EquipTool(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            EquipTool(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            EquipTool(2);
          }
    }

    void EquipTool(int i) {
        if(i>= 0 && i<= 2) {
            //Get Item from inventory
            if(inventorySystem.toolInventory.Count > i) {
                Item item = inventorySystem.toolInventory[i];
                if (item is Weapon weapon)
                {
                    //Load the item into the player's hand
                    if (item != null)
                    {

                        playerhand.SetTool(weapon.handPrefab);

                    }
                }
            } else {
                playerhand.RemoveTool();
            }
        } else {
            Debug.LogError("Tool index out of bounds");

        }
    }
}
