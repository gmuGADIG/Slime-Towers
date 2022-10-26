using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceNode : MonoBehaviour, IInteractable
{
    public GameObject materialType;

    public void interact() {
       GameObject itemDrop = Instantiate(materialType);
       itemDrop.transform.position = this.transform.position;
       Destroy(this.gameObject);
    }

    public string popup_text() {
        // Can change this to whatever :)
        return "Press 'E' to collect!";
    }
}
