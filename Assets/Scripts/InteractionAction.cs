using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAction : Interactable
{

    PlayerInfo playerInfo;
    bool outOfService = false;
    GameObject thisGo;

    TaskInteractible taskInteractible;
    TrickInteractible trickInteractible;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        taskInteractible = GetComponent<TaskInteractible>();
        trickInteractible = GetComponent<TrickInteractible>();
        thisGo = gameObject;
    }

    public override void handleInteraction(bool chaos)
    {
        Debug.Log("interraction chaotique = Interaction Action " + chaos);

        // Has already an action done, just cancel the interaction
        if (playerInfo.IsActionDoing())
        {
            return;
        }

        if(!chaos)
        {
            taskInteractible.StartQTE();
        } else
        {
            trickInteractible.StartTrick();
        }
    }

    public void SetOutOfService(bool outService)
    {
        outOfService = outService;
    }
}
