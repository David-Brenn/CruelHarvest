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
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

    }
 
    void Update()
    {
        

        //Calculate the screen center
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        Ray ray = cam.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        //Cast a ray from the screen center and check if it hits an interactable object 
        if (Physics.Raycast(ray, out hit,100)) {
            Debug.Log(hit.collider.name);
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable != null ) {
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
}
