using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactable
{
    public Item item;
    private InteractionUI interactionUI;

    private void Start() {
        interactionUI = InteractionUI.instance;
    }
    public override void Interact()
    {
        base.Interact();
        ShowPickUpText();
        if(Input.GetKeyDown(KeyCode.F)){
            PickUp();
        }
        
    }

    public override void StopInteract()
    {
        base.StopInteract();
        HidePickUpText();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = InventorySystem.instance.addItem(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

    void ShowPickUpText()
    {
        interactionUI.ShowPickUpInfo();
    }

    void HidePickUpText()
    {
        interactionUI.HidePickUpInfo();
    }

    private void OnDestroy() {
        HidePickUpText();
    }
}
