
using UnityEngine;

///Could also use Colliders and use the is triggered function
/// 
/// <summary>
/// This class 
/// </summary>

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;

    private bool hasInteracted = false;
    Transform player;

    public virtual void Interact() {
        Debug.Log("Interacting with " + transform.name);
    }

    public virtual void StopInteract() {
        Debug.Log("Done interacting with " + transform.name);
    }

    private void Update() {
        
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
