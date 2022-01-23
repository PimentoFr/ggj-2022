using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackerRight : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private SpriteRenderer anim;
    private BoxCollider2D hitbox;

    void Start()
    {
        playerInfo = GetComponentInParent<PlayerInfo>();
        anim = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<BoxCollider2D>();
        anim.enabled = false;
        hitbox.enabled = false;
    }

    private void Update()
    {
        if (playerInfo.GetIsTricking())
            hitbox.enabled = true;
        else
            hitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Tracked enemy = other.gameObject.GetComponent<Tracked>();

        if (enemy != null)
        {
            anim.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Tracked enemy = collision.gameObject.GetComponent<Tracked>();

        if (enemy != null)
        {
            anim.enabled = false;
        }
    }
}
