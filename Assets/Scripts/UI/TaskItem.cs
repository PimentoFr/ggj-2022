using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour
{

    public string taskLabel = "";
    private Text taskText;
    private Image icon;
    
    void Start()
    {
        taskText = transform.Find("TaskLabel").GetComponent<Text>();
        icon = transform.Find("Icon").GetComponent<Image>();
        taskText.text = taskLabel;

        SetDone(false);
    }

    public void SetActionLabel(string action_label)
    {
        taskText.text = action_label;
    }

    public void SetDone(bool boolean)
    {
        if(boolean)
        {
            icon.gameObject.SetActive(true);
            taskText.color = new Color(0.16f, 0.729f, 0.16f);
        }
        else
        {
            icon.gameObject.SetActive(false);
            taskText.color = new Color(0.219f, 0.219f, 0.219f);
        }
    }
}
