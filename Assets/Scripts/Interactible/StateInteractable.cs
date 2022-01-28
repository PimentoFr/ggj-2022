using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateInteractableObject
{
    NORMAL = 0,
    OUT_OF_SERVICE = 1,
    FIXED = 2
}

public class StateInteractable : MonoBehaviour
{
    public GameObject normalSkin;
    public GameObject OOSSkin;
    public GameObject fixedSkin;

    StateInteractableObject state = StateInteractableObject.NORMAL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(StateInteractableObject _state)
    {
        Debug.Log("SetOutOfService :" + _state);
        state = _state;
        switch(state)
        {
            case StateInteractableObject.NORMAL:
                OOSSkin.SetActive(false);
                fixedSkin.SetActive(false);
                normalSkin.SetActive(true);
                break;
            case StateInteractableObject.OUT_OF_SERVICE:
                GetComponent<TaskInteractible>().ResetTask();
                normalSkin.SetActive(false);
                fixedSkin.SetActive(false);
                OOSSkin.SetActive(true);
                break;
            case StateInteractableObject.FIXED:
                normalSkin.SetActive(false);
                OOSSkin.SetActive(false);
                fixedSkin.SetActive(true);
                break;
        }
    }

    public StateInteractableObject GetState()
    {
        return state;
    }
}
