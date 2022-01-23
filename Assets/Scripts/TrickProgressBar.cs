using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrickProgressBar : MonoBehaviour
{
    public Image mask;
    float originalSize;
    PlayerInfo playerInfo;

    float durationS = 100.0f;
    float currentDurationS = 0f;
    GameObject UI_ProgressBar;
    GameObject UI_Sound;

    void Awake()
    {
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        UI_ProgressBar = GameObject.FindWithTag("UI_TrickProgressBar");
        UI_Sound = GameObject.FindWithTag("UI_Sound");
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetUIParent(GameObject parent)
    {
        UI_ProgressBar = parent;
    }

    void SetDuration(float _durationS)
    {
        durationS = _durationS;
    }


    void FixedUpdate()
    {
        currentDurationS += Time.fixedDeltaTime;
        float percent = Mathf.Clamp(100 * currentDurationS / durationS, 0f, 100f);
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * percent / 100f);
        if(percent >= 100.0 || !playerInfo.IsActionDoing())
        {
            OnFinished(percent >= 100.0);
        }
    }

    void OnFinished(bool finished)
    {
        if(finished)
         {
            StopSound();
        }
        
        playerInfo.StopTrick(playerInfo.IsActionDoing());
        Destroy(UI_ProgressBar);
    }


    void PlaySound(AudioClip sound)
    {
        if(sound == null || UI_Sound == null)
        {
            return;
        }
        AudioSource audio = UI_Sound.GetComponent<AudioSource>();

        audio.clip = sound;
        audio.Play();
    }

    void StopSound()
    {
        if(UI_Sound == null)
        {
            return;
        }
        AudioSource audio = UI_Sound.GetComponent<AudioSource>();

        if (audio.clip != null && audio.isPlaying)
        {
            audio.Stop();
        }
    }


    public static bool LaunchProgressBar(PlayerInfo playerInfo, TrickMission mission, GameObject prefabUIProgressBar)
    {
        if (playerInfo.IsActionDoing())
        {
            return false;
        }
        Debug.Log("Enter here");

        playerInfo.SetActionDoing(true);

        GameObject progress = Instantiate(prefabUIProgressBar, new Vector3(0, 0, 0), Quaternion.identity);
        Transform a = progress.transform.GetChild(0).GetChild(0);
        TrickProgressBar progressbar =a.gameObject.GetComponent<TrickProgressBar>();
        //progressbar.SetUIParent(progress);
        progressbar.SetDuration(mission.durationInS);
        Debug.Log("Sound :"+mission.playSound);
        if(mission.playSound != AudioType.NULL) {
            progressbar.PlaySound(AudioClipList.GetAudioClipFromAudioType(mission.playSound));
        }

        return true;
    }
}

