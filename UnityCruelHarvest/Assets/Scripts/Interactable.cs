
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    Transform player;

    private void Update() {
        
        if (isFocus) {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius) {
                Debug.Log("Interact");
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void OnFocused(Transform playerTransform) {
        isFocus = true;
    }
    public void OnDefocus(Transform playerTransform) {
        isFocus = false;

    }
}
