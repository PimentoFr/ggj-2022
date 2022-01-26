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
    PlayerInfo playerInfo;


    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
    }


    public void StartQTE()
    {
        bool isOutOfService = false; // Check if the object is out of service
        int nbKeys = defaultNbKeys; // Number of key for each QTE action

        List<string> listActions = new List<string>();
        List<AudioClip> listSounds = new List<AudioClip>();

        if(isOutOfService) {
            listActions.AddRange(qteActionsOutOfService);
            listSounds.AddRange(qteSoundsOutOfService);
        }
        listActions.AddRange(qteActions);
        listSounds.AddRange(qteSounds);


        QTECreator.LaunchQTE2(prefabUI_QTE, listActions, listSounds, nbKeys, this);
    }

    public void OnQuitQTE(bool success)
    {
        if(success)
        {
            Debug.Log("On Quit QTE");
        }
    }
}
