using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicCon : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject Musicbar;
    private Scrollbar Music;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Music = Musicbar.GetComponent<Scrollbar>();
        audioSource.volume = 1;
    }
    public void VolumeChanged(float newVolume)
    {
        newVolume = Music.value;
        audioSource.volume = newVolume;
    }

}
