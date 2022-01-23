using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskToDo
{
    public TaskType type { get; set; }
    public string taskLabel { get; set; }
    public bool done { get; set; }

    public TaskToDo(TaskType _type, string _taskLabel, bool _done)
    {
        type = _type;
        taskLabel = _taskLabel;
        done = _done;
    }

    public TaskToDo(TaskType _type)
    {
        type = _type;
        /* Search matching task */
        TaskToDo taskToDo = TasksDict.tasks[_type];
        taskLabel = taskToDo.taskLabel;
        done = taskToDo.done;
    }

    public TaskToDo(TaskType _type, bool _done)
    {
        type = _type;
        /* Search matching task */
        TaskToDo taskToDo = TasksDict.tasks[_type];
        taskLabel = taskToDo.taskLabel;
        done = _done;
    }

    public bool IsSameType(TaskType _type)
    {
        return (type == _type);
    }

    public static TaskToDo GetTaskToDoFromList(List<TaskToDo> taskToDoList, TaskType taskType)
    {
        TaskToDo _taskToDo = null;
        foreach (TaskToDo _t in taskToDoList)
        {
            if(_t.IsSameType(taskType))
            {
                _taskToDo = _t;
                break;
            } 
        }
        return _taskToDo;
    }
}
