using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public GameObject interactionText;
    public static InteractionUI instance;

    public string pickUpText = "Press F to pick up";

    private void OnEnable() {
        this.GetComponent<UnityEngine.UI.Image>().enabled = false;
        interactionText.SetActive(false);
    }

    void Awake()
    {
        if(instance != null){
            Debug.LogWarning("There is already a InteractionUI in the scene");
            return;
        } 
            instance = this;
            
        
    }

    public void ShowPickUpInfo()
    {
        this.GetComponent<UnityEngine.UI.Image>().enabled = true;
        interactionText.SetActive(true);
        //q: How can i change the text of Text mesh pro?

        interactionText.GetComponent<TextMeshProUGUI>().text = pickUpText;
    }

    public void HidePickUpInfo()
    {
        this.GetComponent<UnityEngine.UI.Image>().enabled = false;
        interactionText.SetActive(false);
    }


}
