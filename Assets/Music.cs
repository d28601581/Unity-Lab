using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    public Slider BackgroundSlider;
    private float backgroundFloat;
    public AudioSource backgroundAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0){
            backgroundFloat = .25f;
            BackgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref,backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        } else {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            BackgroundSlider.value = backgroundFloat;
        }
    }

    public void saveSoundSettings(){
        PlayerPrefs.SetFloat(BackgroundPref, BackgroundSlider.value);
    }

    void OnAppllicationFocus(bool inFocus){
        if(!inFocus){
            saveSoundSettings();
        }
    }
    public void updateSound(){
        backgroundAudio.volume = BackgroundSlider.value;

        
    }
}
