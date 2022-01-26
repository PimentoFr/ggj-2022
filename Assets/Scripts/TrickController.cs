using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class TrickDuration
{
    public const float durationShortTaskInS = 3.0f;
    public const float durationLongTaskInS = 10.0f;
}

public class TrickController : MonoBehaviour
{
    public float durationShort;
    public float durationLong;
    TrickInteractible trickInteractible;


    float startTick;
    float duration;
    PlayerInfo playerInfo;
    bool enableTimer = false;
    TaskLabel taskLabel;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GetComponent<PlayerInfo>();
        taskLabel = GameObject.FindGameObjectWithTag("UI_TaskLabels").GetComponent<TaskLabel>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enableTimer)
        {
            // Update the jinx bar
            taskLabel.UpdateJinxBar((Time.realtimeSinceStartup - startTick) / duration);

            // Check if the timer is ended
            if ((Time.realtimeSinceStartup - startTick) >= duration) {
                OnTrickFinished();
            }
        }
    }

    public void StartTrickInteractible(TrickInteractible trick)
    {
        trickInteractible = trick;

        // Block player
        playerInfo.SetActionDoing(true);
        
        startTick = Time.realtimeSinceStartup;
        duration = (trick.isLongTask) ? durationLong : durationShort;

        enableTimer = true;
        PlaySound();
    }

    public void OnTrickFinished()
    {
        playerInfo.AddStress(trickInteractible.stressBonus);
        Clean();
    }

    public void OnDetected()
    {
        Debug.Log("On Detected");
        playerInfo.AddStress(trickInteractible.stressOnDetected);
        Clean();
    }

    void Clean()
    {
        enableTimer = false;
        trickInteractible = null;
        playerInfo.SetActionDoing(false);
        taskLabel.UpdateJinxBar(0.0f);
    }

    void PlaySound()
    {
        if(trickInteractible.sound == null)
        {
            return;
        }

        audioSource.PlayOneShot(trickInteractible.sound);
    }
}
