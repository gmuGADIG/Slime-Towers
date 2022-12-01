using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour, IInteractable
{
    

    public string popup_text() {
        return "Press 'E' to talk to this NPC";
    }

    public void interact() {
        // begin dialogue 
    }
}
