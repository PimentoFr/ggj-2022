using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTasks : MonoBehaviour
{
    List<TaskToDo> playerTasks { get; set; }
    public int numberOfLongTask = 1;
    public int numberOfShortTask = 2;
    public GameObject prefabUIObject;
    // Start is called before the first frame update
    void Start()
    {
        playerTasks = new List<TaskToDo>();
        GenerateTasks(numberOfShortTask, numberOfLongTask);

        foreach (var t in playerTasks)
        {
            Debug.Log("task " + t.taskLabel);
        }
    }

    void GenerateTasks(int shortTask, int longTask)
    {

        TasksDict.testPrint();
        /* Populate long task */
        for (int i = 0; i < longTask; i++)
        {
            TaskType taskType = TasksDict.GetLongTask();
            Debug.Log("Generate Task " + taskType);
            if (taskType != TaskType.NULL)
            {
                Debug.Log("OK " + taskType);
                playerTasks.Add(TasksDict.tasks[taskType]);
            }
        }
        /* Populate short task */
        for(int i = 0; i < shortTask; i++)
        {
            TaskType taskType = TasksDict.GetShortTask();
            if(taskType != TaskType.NULL)
            {
                Debug.Log("OK2 " + taskType);
                playerTasks.Add(TasksDict.tasks[taskType]);
            }
        }

        /* Refresh UI */
        RefreshUITask();
    }

    public void RefreshUITask()
    {
        Debug.Log("TEST Refresh");
        prefabUIObject.GetComponent<TaskListUI>().SetTasks(playerTasks);
    }

    public bool isAllTaskDone()
    {
        bool result = true;

        foreach(TaskToDo task in playerTasks)
        {
            if(!task.done)
            {
                result = false;
                break;
            }
        }
        return result;
    }

    public void SetTaskDone(TaskType taskType, bool done)
    {
        List<TaskToDo> listTaskToDo = prefabUIObject.GetComponent<TaskListUI>().GetTasks();
        TaskToDo t = TaskToDo.GetTaskToDoFromList(listTaskToDo, taskType);
        if(t == null)
        {
            /* The task was optionnal */
            return;
        }
        t.done = done;

        /* Refresh Task UI*/
        prefabUIObject.GetComponent<TaskListUI>().Refresh();
    }

}
