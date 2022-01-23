using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftInterraction : Interactable
{
    public string textLog = "logInfo";

    private PlayerMoves player;
    private Vector2 floor1, floor2, floor3;
    private int currentFloor;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMoves>();
        floor1 = GameObject.FindWithTag("F1L").GetComponent<F1L>().transform.position;
        floor2 = GameObject.FindWithTag("F2L").GetComponent<F2L>().transform.position;
        floor3 = GameObject.FindWithTag("F3L").GetComponent<F3L>().transform.position;
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
