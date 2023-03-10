using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string popup_text();
    void interact();
}


/*
    ok so lets think here
    we have an interface with three functions:
	    string popup_text(): returns the text that will show up in the prompt before interaction
	    void interact(): excecutes whatever must be done when interacted with (pick up an item, generator/tower, npcs)
	    void check_popup(): something run on every frame to see if player is within range of popup. will call a UIManager function to turn on popup. some interactables will likely have art.

    popupManager has two functions to handle iinteractables:
	    show_popup( IInteractable object ): Where object is the thing being interacted with
        show_popup( Interactable object, int spriteID ): Same as above, but where spriteID is the id of the sprite to display on the left. ex: with npcs, a profile sprite. IDK if we're actually going to use this.

    UIManager 
*/