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
    AudioSource audioSource;

    void Start()
    {
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        UI_ProgressBar = GameObject.FindWithTag("UI_TrickProgressBar");
        audioSource = GetComponent<AudioSource>();
        originalSize = mask.rectTransform.rect.width;
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
        if(percent >= 100.0)
        {
            OnFinished();
        }
    }

    void OnFinished()
    {
        stopSound();
        playerInfo.StopTrick(true);
        Destroy(UI_ProgressBar);
    }


    void playSound(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }

    void stopSound()
    {
        audioSource.Stop();
    }

    public static bool LaunchProgressBar(PlayerInfo playerInfo, float duration, GameObject prefabUIProgressBar)
    {
        if (playerInfo.IsActionDoing())
        {
            return false;
        }

        playerInfo.SetActionDoing(true);

        GameObject progress = Instantiate(prefabUIProgressBar, new Vector3(0, 0, 0), Quaternion.identity);
        TrickProgressBar progressbar = progress.GetComponent<TrickProgressBar>();
        progressbar.SetDuration(duration);

        return true;
    }
}

