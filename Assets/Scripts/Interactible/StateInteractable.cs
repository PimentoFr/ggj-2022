using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInteractable : MonoBehaviour
{

    public bool isOutOfService = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOutOfService(bool _isOutOfService)
    {
        Debug.Log("SetOutOfService :" + _isOutOfService);
        isOutOfService = _isOutOfService;
        if(isOutOfService) {
            // Force to reset the task
            GetComponent<TaskInteractible>().ResetTask();
        }
    }
}
