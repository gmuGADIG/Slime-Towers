using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public void changeScene(string name){
        Debug.Log("changeScene");
        SceneManager.LoadScene(name);
    }

    public void quitGame() {
        Application.Quit();
    }

    public void backToTitle()
    {
        SceneManager.LoadScene("Title Menu");
    }
}
