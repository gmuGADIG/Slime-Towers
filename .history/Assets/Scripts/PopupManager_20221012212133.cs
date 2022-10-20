using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public Text popupText;
    public Image popupPanel;
    public IInteractable bbjectShowing;

    // Start is called before the first frame update
    void Start()
    {
        // Hide my two elements
        popupText.text = " ";
        popupPanel.color = popupPanel.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void show_popup( IInteractable obj )
    {
        // get the obj string
        // set popuptext to obj string
        // show popuppanel
        // show popuptext
    }

    void hide_popup( IInteractable obj )
    {
        // check if objectshowing matches obj
        // if it does, hide my elements
    }

}
