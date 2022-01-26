using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTasks : MonoBehaviour
{
    public int numberOfLongTask = 2;
    public int numberOfShortTask = 3;
    public GameObject prefabUIObject;

    public List<TaskInteractible> playerTasks;

    public ScenesGest sceneGest;
    // Start is called before the first frame update
    void Start()
    {
        PrepareTasks(numberOfLongTask, numberOfShortTask);
        RefreshUITask();
    }

    private void FixedUpdate()
    {
        if (IsAllTaskDone())
        {
            sceneGest.WonGame();
        }
    }

    GameObject[] GetAllTasksOnScene()
    {
       return GameObject.FindGameObjectsWithTag("ItemInteractable");
    }

    List<TaskInteractible> GetLongTasksOnScene(GameObject[] allTasksGo)
    {
        List<TaskInteractible> listLongTasks = new List<TaskInteractible>();
        foreach(var go in allTasksGo)
        {
            TaskInteractible task = go.GetComponent<TaskInteractible>();
            if(task.qteActions.Length > 1)
            {
                listLongTasks.Add(task);
            }
        }

        return listLongTasks;
    }

    List<TaskInteractible> GetShortTasksOnScene(GameObject[] allTasksGo)
    {
        List<TaskInteractible> listShortTasks = new List<TaskInteractible>();
        foreach (var go in allTasksGo)
        {
            TaskInteractible task = go.GetComponent<TaskInteractible>();
            if (task.qteActions.Length == 1)
            {
                listShortTasks.Add(task);
            }
        }
        return listShortTasks;
    }

    void PrepareTasks(int longTask, int shortTask)
    {
        GameObject[] tasksGo = GetAllTasksOnScene();

        List<TaskInteractible> longTasks = GetLongTasksOnScene(tasksGo);
        List<TaskInteractible> shortTasks = GetShortTasksOnScene(tasksGo);
        Debug.Log("Count tasksGo " + tasksGo.Length);
        Debug.Log("Count longtasks " + longTasks.Count);
        Debug.Log("Count shorttasks " + shortTasks.Count);
        playerTasks.Clear();
        /* Populate long task */
        for (int i = 0; i < longTask; i++)
        {
            if(longTasks.Count == 0)
            {
                Debug.Log("Warning, no more available long task");
                break;
            }
            int rand = Random.Range(0, longTasks.Count);
            TaskInteractible task = longTasks[rand];
            playerTasks.Add(task);
            longTasks.Remove(task);
        }
        /* Populate short task */
        for (int i = 0; i < shortTask; i++)
        {
            if (shortTasks.Count == 0)
            {
                Debug.Log("Warning, no more available short task");
                break;
            }
            int rand = Random.Range(0, shortTasks.Count);
            TaskInteractible task = shortTasks[rand];
            playerTasks.Add(task);
            shortTasks.Remove(task);
        }
    }


    public void RefreshUITask()
    {
        prefabUIObject.GetComponent<TaskListUI>().SetTasks(playerTasks);
    }

    public bool IsAllTaskDone()
    {
        bool result = true;

        foreach(TaskInteractible task in playerTasks)
        {
            if(!task.IsDone())
            {
                result = false;
                break;
            }
        }
        return result;
    }



    public void SetTaskDone(TaskInteractible task, bool done)
    {
        TaskInteractible taskFound = TaskInteractible.FoundTaskInTasks(task, playerTasks);
        if(taskFound != null)
        {
            taskFound.taskDone = done;
        }


        /* Refresh Task UI*/
        prefabUIObject.GetComponent<TaskListUI>().Refresh();
    }
    
}
