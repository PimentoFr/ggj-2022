using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_music : MonoBehaviour
{
    public AudioClip normalBG;
    public AudioClip cursedBG;

    PlayerInfo player;
    AudioSource music;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerInfo>();
        music = GetComponent<AudioSource>();
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
}
