using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public Text popupText;
    public Image popupPanel;
    public IInteractable objectShowing;

    public static PopupManager instance;


    private void Awake() {
        if ( instance == null ) {
            instance = this;
        }
        else {
            Debug.Log( "Error: Two PopupManagers instantiated at once." );
        }
    }

    void Start()
    {
        // Hide my elements
        hide_popup();
    }

    /*
     *  If a popup is showing, check if 'E' is pressed to interact.
     */
    void Update() {
        if ( objectShowing != null ) {
            if ( Input.GetKeyDown(KeyCode.E) ) {
                objectShowing.interact();
                objectShowing = null;
                hide_popup();
            }
        }
    }

    /*
     *  Given an interactable object, display the UI and text.
     *  Will implement popups with sprites (ex: NPC profiles) as an overloaded function.
     */
    public void show_popup( IInteractable obj )
    {
        Debug.Log(obj.popup_text());
        objectShowing = obj;
        popupText.text = obj.popup_text();

        popupPanel.enabled = true;
    }

    /*
     *  Hide the elements of the Popup UI.
     */
    public void hide_popup()
    {
        popupText.text = " ";
        popupPanel.enabled = false;
    }

    
    /*
     *  Checks if player runs close enough to an interactable to display the popup.
     *  Might want to change to being based on which is closer, rather than who it "bumps into" most recently.
     */
     /*
    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.tag.Equals( "Interactable" ) ) {
            objectShowing = collision.GetComponent<IInteractable>();
            show_popup( objectShowing );
        }
    }*/

    /*
     *  If running out of range of an interactable, check if it's the currently displayed popup. If it is, hide the popup.
     */
     /*
    private void OnTriggerExit2D(Collider2D collision) {
        if ( collision.tag.Equals( "Interactable" ) ) {
            if ( collision.GetComponent<IInteractable>().Equals( objectShowing) ) {
                hide_popup();
                objectShowing = null;
            }
        }
    }*/

}
