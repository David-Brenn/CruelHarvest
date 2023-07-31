using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Transform toolsParent;

    private InventorySystem inventorySystem;

    private InventorySlot[] toolSlots;
    private InventorySlot[] itemSlots;
    // Start is called before the first frame update
    void Start()
    {
        inventorySystem = InventorySystem.instance;
        inventorySystem.onItemChangedCallback += UpdateUI;

        itemSlots = itemsParent.GetComponentsInChildren<InventorySlot>();
        toolSlots = toolsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI() {
        Debug.Log("Updating UI");
        for (int i = 0; i < toolSlots.Length; i++) {
            if (i < inventorySystem.toolInventory.Count) {
                toolSlots[i].AddItem(inventorySystem.toolInventory[i]);
            } else {
                toolSlots[i].ClearSlot();
            }
        }
        for (int i = 0; i <itemSlots.Length; i++) {
            if (i < inventorySystem.itemInventory.Count) {
                itemSlots[i].AddItem(inventorySystem.itemInventory[i]);
            } else {
                itemSlots[i].ClearSlot();
            }
        }

    }
}
