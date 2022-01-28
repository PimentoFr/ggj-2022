using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_music : MonoBehaviour
{
    public AudioClip normalBG;
    public AudioClip cursedBG;
    public float effectVolume;

    PlayerInfo player;
    AudioSource music;
    
    bool effectVolumeOn = true;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerInfo>();
        music = GetComponent<AudioSource>();
        effectVolume = 0.5f;

    }

    private void Update()
    {
        if (player.isTricking && music.clip != cursedBG)
        {
            music.clip = cursedBG;
            music.Play();
            Debug.Log("Méchant");
        }
        else if (!player.isTricking && music.clip != normalBG)
        {
            music.clip = normalBG;
            music.Play();
            Debug.Log("Gentil");
        }
    }

    public void SetEffectVolume (float _volume)
    {
        effectVolume = _volume;
        //Debug.Log("le volume des effets est à : " + effectVolume);

    }
     public float GetEffectVolume ()
    {
        if (effectVolumeOn)
        {
            return effectVolume;
        }
        else
            return 0;
    }
    public void SwitchEffectSounds(bool _switch)
    {
        effectVolumeOn = _switch;
        
    }
}
