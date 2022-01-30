using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealLiftInteraction : Interactable
{
    public string textLog = "logInfo";

    private GameObject player;
    private MapGenerator donnees;
    private BoxCollider2D playerCollider;
    private float baseY;
    private int currentFloor;
    private AudioSource audioSource;
    public AudioClip elevatorSound;
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        donnees = GameObject.Find("MapGen").GetComponent<MapGenerator>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
        baseY = player.GetComponent<Transform>().position.y;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void handleInteraction(bool chaos)
    {
        PlaySound(elevatorSound);
       // if (player.GetComponent<Transform>().position.y != donnees.getHauteurTile() * (donnees.etage -1) )
            player.GetComponent<Transform>().position = new Vector2 (player.GetComponent<Transform>().position.x, player.GetComponent<Transform>().position.y + donnees.getHauteurTile());
        if(player.GetComponent<Transform>().position.y > donnees.getHauteurTile()* donnees.etage)
            player.GetComponent<Transform>().position = new Vector2(player.GetComponent<Transform>().position.x, baseY );

        playerCollider.enabled = false;
        playerCollider.enabled = true;
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.volume = GameObject.FindWithTag("BG_music").GetComponent<BG_music>().GetEffectVolume();
        audioSource.PlayOneShot(clip);
    }
}
