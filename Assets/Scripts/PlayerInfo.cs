using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private float stress = 0.0f;
    bool QTEActived = false;
    PlayerMoves playerMove;
    PlayerTasks playerTasks;

    public float riseStressTickPeriodS = 5.0f;
    public float incrementStressValueByTick = 1.0f;
    public float lastTick;
    public bool isTricking = false;

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
        if(!playerMove.getChaos() && ((Time.realtimeSinceStartup - lastTick) >= riseStressTickPeriodS)) {
            AddStress(incrementStressValueByTick);
            lastTick = Time.realtimeSinceStartup;
        }
    }

    public void AddStress(float amount)
    {
        stress = Mathf.Clamp(stress + amount, 0.0f, 100.0f);
        Debug.Log("Stress : " + stress);
        if (stress >= 100.0f)
        {
            Lose();
        }
    }

    public float GetStress()
    {
        return stress;
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
            playerMove.freezeMove = true;
        }
    }

    public void Unfreeze()
    {
        if(freeze)
        {
            /* Enable motions */
            playerMove.freezeMove = false;
            freeze = false;
        }
    }

    public void SetQTEActived(bool actived)
    {
        QTEActived = actived;
        Freeze();
    }

    public void SetIsTricking(bool _isTricking)
    {
        isTricking = _isTricking;
        if(isTricking)
        {
            Freeze();
        } else
        {
            Unfreeze();
        }
    }

    public bool GetIsTricking()
    {
        return isTricking;
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
        SetIsTricking(false);
    }

    public void Lose()
    {
        Debug.Log("To much stress, loooosser");
    }
}
