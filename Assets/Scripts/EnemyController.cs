using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D hitbox;
    SpriteRenderer enemy;
    AudioSource son;

    public GameObject pausing;
    public GameObject borneLeft;
    public GameObject borneRight;
    public int direction = 1;
    public float speed = 3.0f;
    public float timeOut = 3.0f;
    public float portee = 10.0f;

    private float stopTime;
    private Vector2 position;

    void Start()
    {
        pausing = GameObject.FindWithTag("BG_music");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<BoxCollider2D>();
        son = GetComponent<AudioSource>();
        stopTime = 0;
        hitbox.size = new Vector2(portee, 8.0f);
        speed = Random.Range(3f, 8f);
        if (Random.Range(1, 3) == 1)
            direction = -direction;
    }

    
    void FixedUpdate()
    {
        if(!pausing.GetComponent<Pause>().getPaused())
        {
            timeManager();
        }
        else
        {
            anim.enabled = false;
        }
    }

    void move()
    {
        if (rb.position.x < borneLeft.GetComponent<Transform>().position.x || rb.position.x > borneRight.GetComponent<Transform>().position.x)
        {
            direction = -direction;
        }

        if (direction == 1)
            hitbox.offset = new Vector2(hitbox.size.x / 2, 0);

        else
            hitbox.offset = new Vector2(-hitbox.size.x / 2, 0);

        enemy.flipX = (direction != 1);

        position = rb.position;
        position.x += speed * direction * Time.deltaTime;
        rb.MovePosition(position);


        anim.SetBool("isMoving", true);

    }

    void timeManager()
    {
        if (!anim.enabled)
            anim.enabled = true;
        if (stopTime > 0)
        {
            stopTime -= Time.deltaTime;
            
        }

        else
        {
            hitbox.enabled = true;
            anim.SetBool("hasFlicked", false);
            move();
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInfo player = collision.gameObject.GetComponent<PlayerInfo>();

        if(player != null && player.isTricking)
        {
            son.Play();
            if (!player.IsActionDoing())
            {
                player.AddStress(player.incrementStressValueByTick * player.onSightTickMultiplier);
                hitbox.enabled = false;
                stopTime = timeOut;
                anim.SetBool("hasFlicked", true);
                direction = -direction;
                
            }
            else
            {
                player.GetComponent<TrickController>().OnDetected();
            }
        }
        
    }
}
