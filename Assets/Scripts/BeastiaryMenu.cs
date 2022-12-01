using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastiaryMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject beastiary;
    // Start is called before the first frame update
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
        Destroy(beastiary);
    }
}
