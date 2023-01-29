using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterSecs : MonoBehaviour
{

    public Behaviour[] behaviors;
    public float seconds = 0f;
    private float timer = 0f;

    private void OnEnable() {
        timer = 0f;
    }

    private void Update() {
        timer += Time.deltaTime;
        if (timer > seconds) {
            foreach (Behaviour action in behaviors) {
                action.enabled = true;
            }
            this.enabled = false;
        }
    }
}
