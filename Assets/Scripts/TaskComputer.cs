using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskComputer : MonoBehaviour
{
    public Interactable m_callback;
    private Collider2D m_collider;

    GameObject UITasksGO;
    GameObject glowingGO;


    // Start is called before the first frame update
    void Awake()
    {
        m_collider = GetComponent<Collider2D>();
        m_callback = GetComponent<Interactable>();
        glowingGO = transform.GetChild(0).gameObject;
        glowingGO.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 0.3f);
        UITasksGO = GameObject.FindWithTag("UITaskGO");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            UITasksGO.SetActive(true);
            glowingGO.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            UITasksGO.SetActive(false);
            glowingGO.SetActive(false);
        }
    }
}

