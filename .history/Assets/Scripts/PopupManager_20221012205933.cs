using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text PopupText;
    public Image PopupPanel;

    // Start is called before the first frame update
    void Start()
    {
        // Set up and connect to my UI elements
        // For now, just Popup Text and Popup BG
    }

    // Update is called once per frame
    void Update()
    {
        // check if i need to open pause/settings menu
    }

    void show_popup( IInteractable obj )
    {
        // get the obj string
        // set popuptext to obj string
        // show popuppanel
    }
}
