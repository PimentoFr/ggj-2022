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

    PlayerInfo playerInfo;
    PlayerTasks playerTasks;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start TaskIneractible");
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        playerTasks = playerInfo.GetComponent<PlayerTasks>();
    }


    public void StartQTE()
    {
        bool isOutOfService = false; // Check if the object is out of service
        int nbKeys = defaultNbKeys; // Number of key for each QTE action
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
        }

        playerInfo.SetActionDoing(false);
    }

    public bool IsDone()
    {
        return taskDone;
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
