using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    // [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    void Start(){
        if(!PlayerPrefs.HasKey("MusicVolume")){
            PlayerPrefs.SetFloat("MusicVolume", 1);
        }else{
            Load();
        }
    }

    public void SetMusicVolume(){
        AudioListener.volume = musicSlider.value;
        Save();
    }

    private void Load(){
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
}
