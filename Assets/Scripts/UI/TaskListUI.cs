using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaskListUI : MonoBehaviour
{
    public GameObject prefabQteItem;
    List<TaskInteractible> tasksList = new List<TaskInteractible>();
    List<TaskItemUI> tasksItemUIList = new List<TaskItemUI>();

    public GameObject box;

    void Start()
    {
        //box = transform.Find("Box").gameObject;
        Debug.Log("Start " + box);
    }

    public List<TaskInteractible> GetTasks()
    {
        return tasksList;
    }

    public List<TaskItemUI> GetTasksItemUIList()
    {
        return tasksItemUIList;
    }


    public void SetTasks(List<TaskInteractible> _tasksList)
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

    public void CreateItems(List<TaskInteractible> tasksToDoList)
    {
        int i = 0;
        tasksList = tasksToDoList;

        foreach(TaskInteractible taskToDo in tasksToDoList) {
            Vector3 positionItemUi = new Vector3(0, -i * 60 - 40, 0);
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
