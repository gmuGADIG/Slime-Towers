using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public Text PopupText;
    public Image PopupPanel;
    public IInteractable ObjectShowing;

    // Start is called before the first frame update
    void Start()
    {
        // Hide my two elements
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
