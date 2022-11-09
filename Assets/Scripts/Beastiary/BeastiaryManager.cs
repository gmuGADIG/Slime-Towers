using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeastiaryManager : MonoBehaviour
{
    public Dropdown slimeDropdown;
    public Dropdown resourcesDropdown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSlimeChanged(){
        // dropdown index
        //slimeDropdown.value
        Debug.Log("slime changed");
        resourcesDropdown.value = 0;
        // change text of text boxes
        // change image of image box

    }
}
