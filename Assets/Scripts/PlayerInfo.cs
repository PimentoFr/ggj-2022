using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    float stress = 50.0f;
    bool QTEActived = false;
    PlayerMoves playerMove;
    PlayerTasks playerTasks;

    public float riseStressTickPeriodS = 5.0f;
    public float incrementStressValueByTick = 1.0f;
    public float lastTick;

    bool freeze = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = gameObject.GetComponent<PlayerMoves>();
        playerTasks = gameObject.GetComponent<PlayerTasks>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMove.getChaos() && ((Time.realtimeSinceStartup - lastTick) >= riseStressTickPeriodS)) {
            stress += incrementStressValueByTick;
            if(stress >= 100.0f)
            {
                stress = 100.0f;
            }
        }
    }

    public bool IsQTEActived()
    {
        return QTEActived;
    }

    public void Freeze()
    {
        if(!freeze)
        {
            /* Stop all motion */
            freeze = true;
        }
    }

    public void Unfreeze()
    {
        if(freeze)
        {
            /* Enable motions */
            freeze = false;
        }
    }

    public void SetQTEActived(bool actived)
    {
        QTEActived = actived;
        Freeze();
    }

    public void TaskQTEFinished(bool success, TaskType taskType)
    {
        Debug.Log("TaskQTEFinished " + success + " " + taskType);
        if(success)
        {
            playerTasks.SetTaskDone(taskType, true);
        }
        QTEActived = false;
        Unfreeze();
    }

    public void TaskChaosFinished(bool success)
    {
    
    }
}
