using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskToDo
{
    public string taskLabel { get; set; }
    public bool done { get; set; }

    public TaskToDo(string _taskLabel, bool _done)
    {
        taskLabel = _taskLabel;
        done = _done;
    }
}
