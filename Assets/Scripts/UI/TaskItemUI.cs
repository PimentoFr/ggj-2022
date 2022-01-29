using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskItemUI : MonoBehaviour
{

    public string taskLabel = "";
    private Text taskText;
    private Image UncheckImg;
    private Image CheckImg;
    TaskInteractible task;

    void Awake()
    {
        taskText = transform.Find("TaskLabel").GetComponent<Text>();
        UncheckImg = transform.Find("Uncheck").GetComponent<Image>();
        CheckImg = transform.Find("Check").GetComponent<Image>();

        UncheckImg.gameObject.SetActive(true);
        CheckImg.gameObject.SetActive(false);
    }

    public void SetTask(TaskInteractible _task)
    {
        task = _task;
        Refresh();
    }

    public void SetDone(bool boolean)
    {
        if (boolean)
        {
            UncheckImg.gameObject.SetActive(false);
            CheckImg.gameObject.SetActive(true);
            taskText.color = new Color(0.16f, 0.729f, 0.16f);
        }
        else
        {
            UncheckImg.gameObject.SetActive(true);
            CheckImg.gameObject.SetActive(false);
            taskText.color = new Color(0.819f, 0.819f, 0.819f);
            //taskText.color = new Color(0.219f, 0.219f, 0.219f);
        }
    }

    public void Refresh()
    {
        taskText.text = task.taskLabel;
        SetDone(task.IsDone());
    }
}
