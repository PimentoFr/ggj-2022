using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAction : Interactable
{

    public TaskType taskType = TaskType.NULL;
    public GameObject UIQTE;
    GameObject player;
    bool outOfService = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
            QTECreator.LaunchQTE(player, taskType, outOfService, UIQTE);
        } else
        {
            /* Launch Wait */
        }
        
    }

    public void SetOutOfService(bool outService)
    {
        outOfService = outService;
    }
}