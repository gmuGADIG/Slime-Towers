using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public void BackButtonPressed()
    {
        Instantiate(pauseMenu, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(optionsMenu);
    }
}
