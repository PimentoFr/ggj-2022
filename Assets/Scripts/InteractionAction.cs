using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAction : Interactable
{

    PlayerInfo playerInfo;
    GameObject thisGo;

    TaskInteractible taskInteractible;
    TrickInteractible trickInteractible;

    StateInteractable stateInteractable;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        taskInteractible = GetComponent<TaskInteractible>();
        trickInteractible = GetComponent<TrickInteractible>();
        stateInteractable = GetComponent<StateInteractable>();
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
            if(stateInteractable.GetState() == StateInteractableObject.FIXED) {
                // Object already fixed
                return;
            }
            taskInteractible.StartQTE();
        } else
        {
            if(stateInteractable.GetState() == StateInteractableObject.OUT_OF_SERVICE) {
                // Object already out of service
                return;
            }
            trickInteractible.StartTrick();
        }
    }
}
