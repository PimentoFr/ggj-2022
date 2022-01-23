using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInterraction : Interactable
{
    public int taskID;

    public override void handleInteraction(bool chaos)
    {
        /*
        Debug.Log($"Lancer la task {taskID} en interraction chaotique = {chaos}");
        MonSuperScript(taskID);
            -> QTE
            -> Barre d'attente
        */
    }
}
