using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sound : MonoBehaviour {

    // Reference to Audio Source component
    public AudioSource audioSrc;
    public Slider volumeSlider;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float musicVolume = 1f;

	// Use this for initialization
	private void Start () {

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("volume");
        audioSrc.volume = musicVolume;
        volumeSlider.value = musicVolume; 
	}
	
	// Update is called once per frame
	void Update () {

        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
	}

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}