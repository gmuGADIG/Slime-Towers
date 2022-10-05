using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeText : MonoBehaviour
{
    public Text myText;
    public Slider Master;
    void Update(){
        myText.text = "Master Volume: " + Master.value;
    }
}
