using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            backButtonPressed();
        }
    }

    public void backButtonPressed()
    {
        Instantiate(pauseMenu, new Vector3(2.0f, 0, 0), Quaternion.identity);
        Destroy(optionsMenu);
    }
}
