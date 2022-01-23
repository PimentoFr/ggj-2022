using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TaskType
{
    FILL_COFFEE = 0,
    COPY_DOCUMENT = 1,
    WATER_PLANT = 2,
    REPLACE_CHAIR = 3,
    NULL = 999
}

public static class TasksDict
{

    public static Dictionary<TaskType, TaskToDo> tasks = new Dictionary<TaskType, TaskToDo>() {
        {TaskType.FILL_COFFEE,       new TaskToDo(TaskType.FILL_COFFEE, "Préparer un café", false)},
        {TaskType.COPY_DOCUMENT,     new TaskToDo(TaskType.COPY_DOCUMENT, "Faire un photocopie", false)},
        {TaskType.WATER_PLANT,       new TaskToDo(TaskType.WATER_PLANT, "Arroser la plante", false)},
        {TaskType.REPLACE_CHAIR,     new TaskToDo(TaskType.REPLACE_CHAIR, "Remettre à sa place", false)},
    };

    public static readonly TaskType[] LONG_TASKS = new TaskType[]
    {
        TaskType.FILL_COFFEE,
    };

    public static readonly TaskType[] SHORT_TASKS = new TaskType[]
    {
        TaskType.COPY_DOCUMENT,
        TaskType.WATER_PLANT,
        TaskType.REPLACE_CHAIR
    };

    public static List<TaskType> poolLongTasks = new List<TaskType>(LONG_TASKS);
    public static List<TaskType> poolShortTasks = new List<TaskType>(SHORT_TASKS);


    public static TaskType GetLongTask()
    {
        TaskType taskType = TaskType.NULL;
        if(poolLongTasks.Count >= 1)
        {
            int index = Random.Range(0, poolLongTasks.Count);
            taskType = poolLongTasks[index];
            poolLongTasks.Remove(taskType);
        }
        return taskType;
    }
    
    public static void testPrint()
    {
        foreach(var t in LONG_TASKS)
        {
            Debug.Log("tesPrint long " + t);
        }
        foreach (var t in SHORT_TASKS)
        {
            Debug.Log("tesPrint short " + t);
        }

        Debug.Log("==================");
        foreach (var t in poolLongTasks)
        {
            Debug.Log("tesPrint long " + t);
        }
        foreach (var t in poolShortTasks)
        {
            Debug.Log("tesPrint short " + t);
        }
    }

    public static TaskType GetShortTask()
    {
        TaskType taskType = TaskType.NULL;
        if (poolShortTasks.Count >= 1)
        {
            int index = Random.Range(0, poolShortTasks.Count);
            taskType = poolShortTasks[index];
            poolShortTasks.Remove(taskType);
        }
        return taskType;
    }

    public static void ResetPools()
    {
        poolLongTasks = new List<TaskType>(LONG_TASKS);
        poolShortTasks = new List<TaskType>(SHORT_TASKS);
    }
}

