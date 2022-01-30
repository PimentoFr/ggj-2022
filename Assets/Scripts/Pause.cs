using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject menuPause;
    bool paused = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            paused = !paused;
            menuPause.SetActive(paused);
            
        }
    }

    public bool getPaused()
    {
        return paused;
    }

    public void DoPause()
    {
        paused = !paused;
        menuPause.SetActive(paused);
    }
}
