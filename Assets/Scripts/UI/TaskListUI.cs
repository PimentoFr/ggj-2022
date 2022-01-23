using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaskListUI : MonoBehaviour
{
    public GameObject prefabQteItem;
    List<TaskToDo> tasksList = new List<TaskToDo>();
    List<TaskItemUI> tasksItemUIList = new List<TaskItemUI>();

    GameObject box;

    void Start()
    {
        box = transform.Find("Box").gameObject;
        Debug.Log("Start " + box);
    }

    public List<TaskToDo> GetTasks()
    {
        return tasksList;
    }

    public List<TaskItemUI> GetTasksItemUIList()
    {
        return tasksItemUIList;
    }


    public void SetTasks(List<TaskToDo> _tasksList)
    {
        Debug.Log("TEST setTasks");
        tasksList = _tasksList;
        RefreshList();
    }

    public void Refresh()
    {
        foreach(TaskItemUI taskItemUi in tasksItemUIList)
        {
            taskItemUi.Refresh();
        }
    }

    public void RefreshList()
    {
        DestroyItems();
        CreateItems(tasksList);
    }

    public void CreateItems(List<TaskToDo> tasksToDoList)
    {
        int i = 0;
        tasksList = tasksToDoList;

        foreach(TaskToDo taskToDo in tasksToDoList) {
            Vector3 positionItemUi = new Vector3(-349, 360 -i * 60, 0);
            TaskItemUI taskItemUi = Instantiate(prefabQteItem, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<TaskItemUI>();
            taskItemUi.transform.SetParent(box.transform, false);
            taskItemUi.transform.localPosition = positionItemUi;
            taskItemUi.SetTask(taskToDo);
            tasksItemUIList.Add(taskItemUi);
            i++;
        }
    }

    public void DestroyItems()
    {
        foreach(TaskItemUI taskItemUi in tasksItemUIList)
        {
            Destroy(taskItemUi.gameObject);
        }
    }
}
