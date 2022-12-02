using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{   
    public void HandleButton()
    {
        SceneManager.LoadScene("Hub");
        Debug.Log("Button Clicked");
        SceneManager.UnloadScene("Title Menu");
    }

    public void optionsButton(){
        //SceneManager.LoadScene("Options");
        //Debug.log("Options button clicked");
        //SceneManager.UnloadScene("Title Menu");
    }
}
