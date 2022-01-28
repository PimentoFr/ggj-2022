using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftRightInterraction : Interactable
{
    public string textLog = "logInfo";

    private PlayerMoves player;
    private Vector2 floor1, floor2, floor3;
    private int currentFloor;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMoves>();
        floor1 = GameObject.FindWithTag("F1R").GetComponent<F1R>().transform.position;
        floor2 = GameObject.FindWithTag("F2R").GetComponent<F2R>().transform.position;
        floor3 = GameObject.FindWithTag("F3R").GetComponent<F3R>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void handleInteraction(bool chaos)
    {
        Debug.Log(textLog);
        if (player.transform.position.y == floor1.y)
            player.transform.position = floor2;
        else if (player.transform.position.y == floor2.y)
            player.transform.position = floor3;
        else if (player.transform.position.y == floor3.y)
            player.transform.position = floor1;


    }
}
