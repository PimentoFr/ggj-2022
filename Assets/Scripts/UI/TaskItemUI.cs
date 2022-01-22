using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskItemUI : MonoBehaviour
{

    public string taskLabel = "";
    private Text taskText;
    private Image icon;
    TaskToDo task = new TaskToDo("", false);

    void Awake()
    {
        taskText = transform.Find("TaskLabel").GetComponent<Text>();
        icon = transform.Find("Icon").GetComponent<Image>();

        icon.gameObject.SetActive(false);
    }

    public void SetTask(TaskToDo _task)
    {
        task = _task;
        Refresh();
    }

    public void SetDone(bool boolean)
    {
        if (boolean)
        {
            icon.gameObject.SetActive(true);
            taskText.color = new Color(0.16f, 0.729f, 0.16f);
        }
        else
        {
            icon.gameObject.SetActive(false);
            taskText.color = new Color(0.819f, 0.819f, 0.819f);
            //taskText.color = new Color(0.219f, 0.219f, 0.219f);
        }
    }

    public void Refresh()
    {
        taskText.text = task.taskLabel;
        SetDone(task.done);
    }
}
