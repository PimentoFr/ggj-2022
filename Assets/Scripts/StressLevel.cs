using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressLevel : MonoBehaviour
{
    public Image mask;
    float originalSize;
    PlayerInfo playerInfo;

    void Start()
    {
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        originalSize = mask.rectTransform.rect.width;
    }

    void FixedUpdate()
    {
        float stressPercent = Mathf.Clamp(playerInfo.GetStress(), 0f, 100f);
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * stressPercent / 100f);
    }
}
