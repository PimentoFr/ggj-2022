using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.GetComponent<PlayerTasks>().SetTaskDone(TaskType.FILL_COFFEE, true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<PlayerTasks>().SetTaskDone(TaskType.COPY_DOCUMENT, true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.GetComponent<PlayerTasks>().SetTaskDone(TaskType.WATER_PLANT, true);
        }
    }
}
