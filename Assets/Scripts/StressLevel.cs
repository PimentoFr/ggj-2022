using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressLevel : MonoBehaviour
{
    public Image mask;

    [Range(0f, 100f)]
    public float stressPercent = 0f;

    float originalSize;

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    void FixedUpdate()
    {
        stressPercent = Mathf.Clamp(stressPercent, 0f, 100f);
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * stressPercent / 100f);
    }
}
