using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePopup : MonoBehaviour
{
    public Behaviour[] nextScripts;
    // Start is called before the first frame update
    void OnEnable()
    {
        PopupManager.instance.hide_popup();
        foreach(Behaviour action in nextScripts) {
            action.enabled = true;
        }
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
