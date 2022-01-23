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
            if (obj.GetComponent<PlayerMoves>().isChaos)
            {
                glowingGO.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                glowingGO.GetComponent<SpriteRenderer>().color = Color.green;
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
