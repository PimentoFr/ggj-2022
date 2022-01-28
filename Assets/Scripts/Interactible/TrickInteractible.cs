using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrickInteractible : MonoBehaviour
{
    // Start is called before the first frame update
    public string trickLabel;
    
    [Range(-100.0f, 0.0f)]
    public float stressBonus;

    [Range(0.0f, 100.0f)]
    public float stressOnDetected;

    public bool isLongTask;

    public AudioClip sound;

    TrickController  trickController;
    void Start()
    {
        trickController = GameObject.FindGameObjectWithTag("Player").GetComponent<TrickController>();
    }

    public void StartTrick() {
        // Check if a trick is already playing
        trickController.StartTrickInteractible(this);
    }
}
