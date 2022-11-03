using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseListener : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1.0f)
        {
            Instantiate(pauseMenu, new Vector3(2.0f, 0, 0), Quaternion.identity);
            ManagerScript.gm.pauseGame();
        }
        //Debug.Log(Time.timeScale);
    }
}
