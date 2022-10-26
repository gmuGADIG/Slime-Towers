using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using System.Collections.Generic;

public class MasterVolumeDisplay : MonoBehaviour {
  public Slider sliderUI;
  public TMP_Text sliderText;
    public AudioMixerGroup group;

    public void Start() {
        sliderText = GetComponent<TMP_Text>();
        float val;
        group.audioMixer.GetFloat(group.name + "Vol", out val);
        Debug.Log(val);
        val = Mathf.Pow(10, (val/20));
        Debug.Log(val);
        sliderUI.value = val;
        
    }

    public void SliderChanged(float value)
    {
        group.audioMixer.SetFloat(group.name+"Vol", Mathf.Log10(value) * 20);
        sliderText.text = Mathf.RoundToInt(sliderUI.normalizedValue * 100) + "%";
    }

    public void ShowMasterSliderValue () {
    string sliderMessage = "Master Volume: " + sliderUI.value;
        //Debug.Log(sliderMessage);
        //sliderText.text = sliderMessage;
        SliderChanged(sliderUI.value);
    }

    public void ShowMusicSliderValue () {
        string sliderMessage = "Music Volume: " + sliderUI.value;
        //Debug.Log(sliderMessage);
        //sliderText.text = sliderMessage;
        SliderChanged(sliderUI.value);
    }

    public void ShowSFXSliderValue() {
        string sliderMessage = "SFX Volume: " + sliderUI.value;
        //Debug.Log(sliderMessage);
        //sliderText.text = sliderMessage;
        SliderChanged(sliderUI.value);
    }
}