using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterraction : MonoBehaviour
{
    public Interactable m_callback;
    private Collider2D m_collider;
    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_callback = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowTaskLabel(PlayerInfo playerInfo)
    {
        StateInteractableObject state = GetComponent<StateInteractable>().GetState();
        if(playerInfo.isTricking)
        {
            if(state == StateInteractableObject.OUT_OF_SERVICE) {
                //The object is already of service, don't show the action text
                return;
            }
            TrickInteractible t = GetComponent<TrickInteractible>();
            GameObject.FindGameObjectWithTag("UI_TaskLabels").GetComponent<TaskLabel>().ShowTaskLabel(
                t.trickLabel,
                true,
                t.isLongTask
                );
        } else
        {
            if(state == StateInteractableObject.FIXED) {
                //The object is already of service, don't show the action text
                return;
            }
            TaskInteractible t = GetComponent<TaskInteractible>();
            GameObject.FindGameObjectWithTag("UI_TaskLabels").GetComponent<TaskLabel>().ShowTaskLabel(
                t.taskLabel,
                false,
                t.isLong
                );
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Player")
        {
            obj.GetComponent<PlayerMoves>().setInteractionCallback(m_callback);
            // Display Text
            ShowTaskLabel(obj.GetComponent<PlayerInfo>());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Player")
        {
            obj.GetComponent<PlayerMoves>().setInteractionCallback(null);
            // Hide Task label
            GameObject.FindGameObjectWithTag("UI_TaskLabels").GetComponent<TaskLabel>().HideTaskLabel();
        }
    }
}
