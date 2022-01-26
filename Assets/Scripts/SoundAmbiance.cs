using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAmbiance : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();

        audio.clip = AudioClipList.GetAudioClipFromAudioType(AudioType.AMBIANCE_LOOP);
        audio.volume = 0.2f;
        audio.Play();
    }

    public void SetAmbiance(AudioType type)
    {
        audio.clip = AudioClipList.GetAudioClipFromAudioType(type);
        if(type == AudioType.AMBIANCE_PUNK) {
            audio.volume = 0.1f;
            
        } 
        
        else if(type == AudioType.AMBIANCE_LOOP)
        {
            audio.volume = 0.5f;
        }
        else
        {
            audio.volume = 1.0f;
        }
        audio.Play();
    }

}
