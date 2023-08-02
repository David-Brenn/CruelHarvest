using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    public Interactable focus;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        //Calculate the screen center
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        Ray ray = cam.ScreenPointToRay(screenCenter);
        RaycastHit hit;

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

    void SetFocus(Interactable newFocus) { 
        focus = newFocus;
    }

    void RemoveFocus() {
        focus = null;
    }
}
