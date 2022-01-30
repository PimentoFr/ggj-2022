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
    public GameObject pausing;

    float duration;
    PlayerInfo playerInfo;
    bool enableTimer = false;
    TaskLabel taskLabel;
    AudioSource audioSource;
    float timeTricking = 0;
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
        if(!pausing.GetComponent<Pause>().getPaused())
        {
            if (enableTimer)
            {
                timeTricking -= Time.deltaTime;
                // Update the jinx bar
                taskLabel.UpdateJinxBar((duration - timeTricking) / duration);

                // Check if the timer is ended
                if (timeTricking <= 0)
                {
                    OnTrickFinished();
                }
            }
        }
    }

    public void StartTrickInteractible(TrickInteractible trick)
    {
        trickInteractible = trick;

        // Block player
        playerInfo.SetActionDoing(true);
        
        duration = (trick.isLongTask) ? durationLong : durationShort;

        enableTimer = true;
        timeTricking = duration;
        PlaySound();
    }

    public void OnTrickFinished()
    {
        playerInfo.AddStress(trickInteractible.stressBonus);
        trickInteractible.SetAsOutOfService();
        Clean();
    }

    public void OnDetected()
    {
        Debug.Log("On Detected");
        playerInfo.AddStress(trickInteractible.stressOnDetected);
        audioSource.Stop();
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

        audioSource.volume = GameObject.FindGameObjectWithTag("BG_music").GetComponent<BG_music>().GetEffectVolume();
        audioSource.PlayOneShot(trickInteractible.sound);
    }
}
