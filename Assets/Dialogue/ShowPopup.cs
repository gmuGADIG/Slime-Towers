using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopup : MonoBehaviour
{
    public string text;
    public Behaviour[] nextScripts;
    // Start is called before the first frame update
    void Start()
    {
        PopupManager.instance.show_popup(text);
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
