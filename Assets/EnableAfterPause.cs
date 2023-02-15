 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterPause : MonoBehaviour
{

    public Behaviour[] behaviors;

    private void OnEnable() {
        
    }

    private void Update() {

        if (Input.GetKey(KeyCode.Escape)) {
            foreach (Behaviour action in behaviors) {
                action.enabled = true;
            }
            this.enabled = false;
        }
    }
}
