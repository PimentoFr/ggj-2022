using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum TaskType
{

    COPY_DOCUMENT = 0,
    WATER_PLANT = 1,
    DEBUG_PC = 2,
    GET_BILL = 3,
    CALL_CLIENT = 4,
    FILL_COFFEE = 5,
    SIGN_CONTRACT = 6,
    STAPLE_DOCUMENT = 7,
    ORDER_FOLDER = 8,
    REPLACE_POSTER = 9,
    REPLACE_CHAIR = 10,

    WRITE_AGENDA = 11,

    NULL = 999
}

public static class TasksDict
{

    public static Dictionary<TaskType, TaskToDo> tasks = new Dictionary<TaskType, TaskToDo>() {
        {TaskType.COPY_DOCUMENT,     new TaskToDo(TaskType.COPY_DOCUMENT, "Copy a document", false)},
        {TaskType.WATER_PLANT,       new TaskToDo(TaskType.WATER_PLANT, "Water plant", false)},
        {TaskType.DEBUG_PC,          new TaskToDo(TaskType.DEBUG_PC, "Fix computer", false)},
        {TaskType.GET_BILL,          new TaskToDo(TaskType.GET_BILL, "Get the bill", false)},
        {TaskType.CALL_CLIENT,       new TaskToDo(TaskType.CALL_CLIENT, "Call the client", false)},
        {TaskType.FILL_COFFEE,       new TaskToDo(TaskType.FILL_COFFEE, "Make a coffee", false)},
        {TaskType.SIGN_CONTRACT,     new TaskToDo(TaskType.FILL_COFFEE, "Make a coffee", false)},
        {TaskType.STAPLE_DOCUMENT,   new TaskToDo(TaskType.STAPLE_DOCUMENT, "Staple documents", false)},
        {TaskType.ORDER_FOLDER,      new TaskToDo(TaskType.ORDER_FOLDER, "Order files", false)},
        {TaskType.REPLACE_POSTER,    new TaskToDo(TaskType.REPLACE_POSTER, "Place poster", false)},
        {TaskType.REPLACE_CHAIR,     new TaskToDo(TaskType.REPLACE_CHAIR, "Place chair", false)},
        //{TaskType.WRITE_AGENDA,      new TaskToDo(TaskType.WRITE_AGENDA, "Write the agenda", false)},
    };

    public static readonly TaskType[] LONG_TASKS = new TaskType[]
    {
        TaskType.COPY_DOCUMENT,
        TaskType.DEBUG_PC,
        TaskType.CALL_CLIENT,
        TaskType.FILL_COFFEE,
        TaskType.SIGN_CONTRACT,
    };

    public static readonly TaskType[] SHORT_TASKS = new TaskType[]
    {
        TaskType.WATER_PLANT,
        TaskType.GET_BILL,
        TaskType.STAPLE_DOCUMENT,
        TaskType.ORDER_FOLDER,
        TaskType.REPLACE_POSTER,
        TaskType.REPLACE_CHAIR,
        //TaskType.WRITE_AGENDA
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

