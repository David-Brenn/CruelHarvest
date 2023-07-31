using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{

    Item item;

    public Image icon;

    public void AddItem(Item newItem) {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot() {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
  
}
