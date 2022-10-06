using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class MasterVolumeDisplay : MonoBehaviour {
  public Slider sliderUI;
  private TMP_Text sliderText;

  void Start () {
    sliderText = GetComponent<TMP_Text>();

    ShowSliderValue();
  }

  public void ShowSliderValue () {
    string sliderMessage = "Master Volume: " + sliderUI.value;
    Debug.Log(sliderMessage);
    sliderText.text = sliderMessage;
  }

  public void ShowMusicSliderValue () {
    string sliderMessage = "Music Volume: " + sliderUI.value;
    Debug.Log(sliderMessage);
    sliderText.text = sliderMessage;
  }

  public void ShowSFXSliderValue () {
    string sliderMessage = "SFX Volume: " + sliderUI.value;
    Debug.Log(sliderMessage);
    sliderText.text = sliderMessage;
  }
}