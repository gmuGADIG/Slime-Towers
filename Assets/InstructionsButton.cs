using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButton : MonoBehaviour
{
    public void HandleButton()
    {
        SceneManager.LoadScene("Instruction Menu");
        //Debug.Log("Button Clicked");
        //SceneManager.UnloadScene("Title Menu");
    }
}
