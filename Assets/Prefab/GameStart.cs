using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{   
    public void HandleButton()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Button Clicked");
        SceneManager.UnloadScene("Title Menu");
    }
}
