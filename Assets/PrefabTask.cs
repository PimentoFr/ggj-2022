using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTask : MonoBehaviour
{

    public Sprite normalSkin;
    public Sprite HSSkin;
    public Sprite cleanSkin;
    public Sprite glowNormal;
    public Sprite glowTricked;

    public string task;
    public List<string> sousTaches;
    public string tacheEnfant;
    public string tacheAdditionnelle;
    public List<AudioClip> sousTachesSound;
    public AudioClip tacheEnfantSound;
    public AudioClip tacheAddSound;


    bool isTricked = false;
    bool isClean = false;
    SpriteRenderer image;
    AudioSource son;
    BoxCollider2D m_collider;
    GameObject glowingGO;
    SpriteRenderer glow;

    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        son = GetComponent<AudioSource>();
        m_collider = GetComponent<BoxCollider2D>();
        glowingGO = transform.GetChild(0).gameObject;
        glow = glowingGO.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        changeGlow();


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            if (obj.GetComponent<PlayerInfo>().GetIsTricking())
            {
                glowingGO.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.3f);
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

    void changeGlow()
    {
        if (isTricked)
            glow.sprite = glowTricked;
        else
            glow.sprite = glowNormal;
    }
}
