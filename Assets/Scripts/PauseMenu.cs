using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public void OptionsButtonPressed()
    {
        Instantiate(optionsMenu, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(pauseMenu);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        Destroy(pauseMenu);
    }
}
