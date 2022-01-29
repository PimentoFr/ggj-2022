using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glow : MonoBehaviour
{
    public Interactable m_callback;
    private Collider2D m_collider;
    public bool glowEnabledEverytime = false;
    public bool isElevator = false;

    GameObject glowingGO;
    GameObject interactibleGO;
    GameObject spacebarGO;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_callback = GetComponent<Interactable>();
        glowingGO = transform.GetChild(0).gameObject;
        interactibleGO = transform.parent.gameObject;
        
        spacebarGO = GameObject.FindGameObjectWithTag("SpaceBar");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool isSpacebar = true;
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            if (isElevator)
            {
                glowingGO.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 0.3f);
                glowingGO.SetActive(true);
                GameObject.FindGameObjectWithTag("UI_TaskLabels").GetComponent<TaskLabel>().ShowTaskLabel("Take lift", false, false);
            }
            else
            {

                if (obj.GetComponent<PlayerInfo>().GetIsTricking() &&
                    (glowEnabledEverytime || interactibleGO.GetComponent<StateInteractable>().GetState() != StateInteractableObject.OUT_OF_SERVICE))
                {
                    glowingGO.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.3f);
                    glowingGO.SetActive(true);
                }
                else if (!obj.GetComponent<PlayerInfo>().GetIsTricking() &&
                        (glowEnabledEverytime || interactibleGO.GetComponent<StateInteractable>().GetState() != StateInteractableObject.FIXED))
                {
                    glowingGO.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0.3f);
                    glowingGO.SetActive(true);
                }
                else
                {
                    glowingGO.SetActive(false);
                    isSpacebar = false;
                }
            }

            if ((obj.GetComponent<PlayerInfo>().IsActionDoing()) || !isSpacebar)
            {
                spacebarGO.GetComponent<Image>().enabled = false;
            }
            else
            {
                spacebarGO.GetComponent<Image>().enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            glowingGO.SetActive(false);
            spacebarGO.GetComponent<Image>().enabled = false;
            if (isElevator)
            {
                GameObject.FindGameObjectWithTag("UI_TaskLabels").GetComponent<TaskLabel>().HideTaskLabel();
            }
        }
    }
}
