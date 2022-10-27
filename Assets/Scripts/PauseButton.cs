using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && Time.timeScale == 1.0f)
        {
            Instantiate(pauseMenu, new Vector3(0, 0, 0), Quaternion.identity);
            Time.timeScale = 0f;
        }
    }
}
