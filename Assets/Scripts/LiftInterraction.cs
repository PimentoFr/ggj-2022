using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftInterraction : Interactable
{
    public string textLog = "logInfo";

    private PlayerMoves player;
    private Vector2 destination;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMoves>();
        destination = GameObject.FindWithTag("F2L").GetComponent<F2L>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void handleInteraction(bool chaos)
    {
        Debug.Log(textLog);
        player.transform.position = destination;

    }
}
