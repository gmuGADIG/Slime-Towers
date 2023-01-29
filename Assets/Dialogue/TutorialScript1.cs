using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript1 : MonoBehaviour
{
    private GameObject playerObject;
    private PlayerMovement playerMovementScript;
    public Behaviour[] nextScripts;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("O_Player");
        playerMovementScript = playerObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.canInteract == true) {
            playerMovementScript.canInteract = false;
            foreach (Behaviour nextScript in nextScripts) {
                nextScript.enabled = true;
            }
            this.enabled = false;
        }
    }
}
