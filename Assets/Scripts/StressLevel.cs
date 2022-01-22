using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressLevel : MonoBehaviour
{
    public float stressPercent;

    void Start()
    {
        stressPercent = 0f;
    }

    void FixedUpdate()
    {
        stressPercent = Mathf.Clamp(stressPercent, 0f, 100f);
        transform.localScale = new Vector2(stressPercent / 100f,1f);
    }
}
