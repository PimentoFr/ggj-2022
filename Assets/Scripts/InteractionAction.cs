using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAction : Interactable
{

    public TaskType taskType = TaskType.NULL;
    public TrickType trickType = TrickType.NULL;
    GameObject player;
    bool outOfService = false;
    GameObject thisGo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        thisGo = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void handleInteraction(bool chaos)
    {
        Debug.Log("interraction chaotique = Interaction Action " + chaos);
        if(!chaos)
        {
            /* Launch QTE */
            if(taskType == TaskType.NULL)
            {
                Debug.Log("Task Type Null");
                return;
            }

            //TODO: Launch QTE
            Debug.Log("Launch QTE");
            player.GetComponent<PlayerInfo>().startQTE(taskType, outOfService, thisGo);
        } else
        {
            /* Launch Wait */
            if (trickType == TrickType.NULL)
            {
                Debug.Log("Trick Type Null");
                return;
            }
            Debug.Log("Launch Trick Progress Bar");
            player.GetComponent<PlayerInfo>().StartTrick(trickType, thisGo);
        }
        
    }

    public void SetOutOfService(bool outService)
    {
        outOfService = outService;
    }
}
