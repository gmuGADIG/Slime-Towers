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
        val = Mathf.Pow(10, (val)/40);
        Debug.Log(val);
        sliderUI.value = val;
        
    }

    public void SliderChanged(float value, string sliderName)
    {
        group.audioMixer.SetFloat(group.name+"Vol", Mathf.Log10(value)*40);
        sliderText.text = sliderName + Mathf.RoundToInt(sliderUI.normalizedValue * 100) + "%";
    }

    public void ShowMasterSliderValue () {
        //Debug.Log(sliderMessage);
        //sliderText.text = sliderMessage;
        SliderChanged(sliderUI.value, "Master Volume: ");
    }

    public void ShowMusicSliderValue () {
        //Debug.Log(sliderMessage);
        //sliderText.text = sliderMessage;
        SliderChanged(sliderUI.value, "Music Volume: ");
    }

    public void ShowSFXSliderValue() {
        //Debug.Log(sliderMessage);
        //sliderText.text = sliderMessage;
        SliderChanged(sliderUI.value, "SFX Volume: ");
    }
}