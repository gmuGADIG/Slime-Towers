 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterMove : MonoBehaviour
{

    public Behaviour[] behaviors;

    private void OnEnable() {
        
    }

    private void Update() {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            foreach (Behaviour action in behaviors) {
                action.enabled = true;
            }
            this.enabled = false;
        }
    }
}
