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

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Player")
        {
            obj.GetComponent<PlayerMoves>().setInteractionCallback(m_callback);
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Player")
        {
            obj.GetComponent<PlayerMoves>().setInteractionCallback(null);
        }
        
    }
}
