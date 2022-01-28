using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInteractible : MonoBehaviour
{

    // Task parameters
    public string taskLabel;
    public string[] qteActions;
    public AudioClip[] qteSounds;


    // Added actions for out of service
    public string[] qteActionsOutOfService;
    public AudioClip[] qteSoundsOutOfService;


    public int defaultNbKeys = 3;

    public GameObject prefabUI_QTE;
    public bool taskDone;
    public bool isLong;

    PlayerInfo playerInfo;
    PlayerTasks playerTasks;

    public float stressToLevel1 = 33.0f;
    public int nbKeyToLevel1 = 2;
    public float stressToLevel2 = 66.0f;
    public int nbKeyToLevel2 = 4;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start TaskIneractible");
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        playerTasks = playerInfo.GetComponent<PlayerTasks>();
        isLong = (qteActions.Length > 1);
    }


    public void StartQTE()
    {
        bool isOutOfService = GetComponent<StateInteractable>().GetState() == StateInteractableObject.OUT_OF_SERVICE; // Check if the object is out of service
        int nbKeys = defaultNbKeys;
        // Add nb keys from stress
        float stress = playerInfo.GetStress();
        if(stress >= stressToLevel2) {
            nbKeys +=nbKeyToLevel2;
        }
        else if(stress >= stressToLevel1) {
            nbKeys +=nbKeyToLevel1;
        }

        Debug.Log("Start TaskIneractible START QTE");

        List<string> listActions = new List<string>();
        List<AudioClip> listSounds = new List<AudioClip>();

        if(isOutOfService) {
            listActions.AddRange(qteActionsOutOfService);
            listSounds.AddRange(qteSoundsOutOfService);
        }
        listActions.AddRange(qteActions);
        listSounds.AddRange(qteSounds);

        playerInfo.SetActionDoing(true);
        QTECreator.LaunchQTE2(prefabUI_QTE, listActions, listSounds, nbKeys, this);
    }

    public void OnQuitQTE(bool success)
    {
        Debug.Log("On Quit QTE");
        if (success)
        {
            /* Set the task has done */
            taskDone = true;
            playerTasks.SetTaskDone(this, true);
            GetComponent<StateInteractable>().SetState(StateInteractableObject.FIXED);
        }

        playerInfo.SetActionDoing(false);
    }

    public bool IsDone()
    {
        return taskDone;
    }

    public void ResetTask() {
        playerTasks.SetTaskDone(this, false);
    }

    public static TaskInteractible FoundTaskInTasks(TaskInteractible match, List<TaskInteractible> tasksList)
    {
        TaskInteractible taskFound = null;
        foreach(var task in tasksList)
        {
            if(task.taskLabel == match.taskLabel)
            {
                taskFound = task;
                break;
            }
        }

        return taskFound;
    }
}
