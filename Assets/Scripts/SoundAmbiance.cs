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
        audio.Play();
    }

    public void SetAmbiance(AudioType type)
    {
        audio.clip = AudioClipList.GetAudioClipFromAudioType(type);
        audio.Play();
    }

}
