using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionToTitleScreen : MonoBehaviour{
    public void HandleButton(){
        SceneManager.LoadScene("Title Menu");
    }
}
