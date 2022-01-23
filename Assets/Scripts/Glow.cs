using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public Interactable m_callback;
    private Collider2D m_collider;

    GameObject glowingGO;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_callback = GetComponent<Interactable>();
        glowingGO = transform.GetChild(0).gameObject;
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
            if (obj.GetComponent<PlayerInfo>().GetIsTricking())
            {
                glowingGO.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,0.3f);
            }
            else
            {
                glowingGO.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0.3f);
            }

            glowingGO.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            glowingGO.SetActive(false);
        }
    }
}
