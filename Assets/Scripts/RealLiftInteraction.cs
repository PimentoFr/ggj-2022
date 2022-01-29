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
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        donnees = GameObject.Find("MapGen").GetComponent<MapGenerator>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
        baseY = player.GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void handleInteraction(bool chaos)
    {
       // if (player.GetComponent<Transform>().position.y != donnees.getHauteurTile() * (donnees.etage -1) )
            player.GetComponent<Transform>().position = new Vector2 (player.GetComponent<Transform>().position.x, player.GetComponent<Transform>().position.y + donnees.getHauteurTile());
        if(player.GetComponent<Transform>().position.y > donnees.getHauteurTile()* donnees.etage)
            player.GetComponent<Transform>().position = new Vector2(player.GetComponent<Transform>().position.x, baseY );

        playerCollider.enabled = false;
        playerCollider.enabled = true;
    }
}
