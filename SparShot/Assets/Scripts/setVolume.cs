using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setVolume : MonoBehaviour
{
    public AudioSource AudioSourceObject;
    // Start is called before the first frame update
    void Awake()
    {
        AudioSourceObject = GetComponent<AudioSource>();
        AudioSourceObject.volume = PlayerPrefs.GetFloat("Options_VolumeLevel");
    }
}
