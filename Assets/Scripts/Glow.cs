using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public Interactable m_callback;
    private Collider2D m_collider;

    GameObject glowingGO;
    GameObject interactibleGO;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_callback = GetComponent<Interactable>();
        glowingGO = transform.GetChild(0).gameObject;
        interactibleGO = transform.parent.gameObject;
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
            if (obj.GetComponent<PlayerInfo>().GetIsTricking() && 
                interactibleGO.GetComponent<StateInteractable>().GetState() != StateInteractableObject.OUT_OF_SERVICE)
            {
                glowingGO.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,0.3f);
                glowingGO.SetActive(true);
            }
            else if(!obj.GetComponent<PlayerInfo>().GetIsTricking() && 
                    interactibleGO.GetComponent<StateInteractable>().GetState() != StateInteractableObject.FIXED)
            {
                glowingGO.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0.3f);
                glowingGO.SetActive(true);
            }

            else {
                glowingGO.SetActive(false);
            }            
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
