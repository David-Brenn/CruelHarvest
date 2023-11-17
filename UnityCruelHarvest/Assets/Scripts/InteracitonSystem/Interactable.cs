
using UnityEngine;

///Could also use Colliders and use the is triggered function
/// 
/// <summary>
/// This class is used to interact with objects in the world. Apply this script to a object that you want to be interactable. 
/// When a item is in focus meaing the player is watching it, the player can interact with it by pressing the interact button.
/// </summary>

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;

    private bool hasInteracted = false;
    Transform player;


    /// <summary>
    /// This function is called when the player interacts with the object. It is a virtual function so it can be overriden in the child class to define what happens when the player interacts with the object.
    /// </summary> 
    public virtual void Interact() {
        Debug.Log("Interacting with " + transform.name);
    }

    public virtual void StopInteract() {
        Debug.Log("Done interacting with " + transform.name);
    }

    private void Update() {
        
        //If the player is focusing on the object. The object calculates the distance between the player and itself. If the distance is smaller than the radius, the player can interact with it.
        if (isFocus) {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius) {
                Debug.Log("Interact");
                hasInteracted = true;
                Interact();
            } else {
                if (hasInteracted) {
                    StopInteract();
                    hasInteracted = false;
                }
            }
        } else {
            if (hasInteracted) {
                StopInteract();
                hasInteracted = false;
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void OnFocused(Transform playerTransform) {
        hasInteracted = false;
        isFocus = true;
        player = playerTransform;
    }
    public void OnDefocus() {
        isFocus = false;
        player = null;

    }
}
