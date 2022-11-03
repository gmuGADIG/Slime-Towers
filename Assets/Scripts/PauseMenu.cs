using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject beastiary;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0f)
        {
            resumeButtonPressed();
        }
    }

    public void optionsButtonPressed()
    {
        Instantiate(optionsMenu, new Vector3(2.0f, 0, 0), Quaternion.identity);
        Destroy(pauseMenu);
    }

    public void resumeButtonPressed()
    {
        Destroy(pauseMenu);
        ManagerScript.gm.unpauseGame();
    }

    public void beastiaryButtonPressed()
    {
        Instantiate(beastiary, new Vector3(2.0f, 0, 0), Quaternion.identity);
        Destroy(pauseMenu);
    }
}
