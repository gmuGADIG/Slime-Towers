using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeastiaryManager : MonoBehaviour
{
    public Dropdown slimeDropdown;
    public Dropdown enemyDropdown;
    public Dropdown resourcesDropdown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSlimeChanged(int newSlime){
        Debug.Log("slime changed");
        enemyDropdown.value = 0;
        resourcesDropdown.value = 0;
    }
}
