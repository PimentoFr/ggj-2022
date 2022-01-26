using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D hitbox;
    SpriteRenderer enemy;

    
    public int direction = 1;
    public float speed = 3.0f;
    public float timeChange = 3.0f;
    public float timeOut = 3.0f;
    public float portee = 10.0f;

    private float movingTime;
    private Vector2 position;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<BoxCollider2D>();
        movingTime = timeChange;
        hitbox.size = new Vector2(portee, 8.0f);
    }

    
    void FixedUpdate()
    {
        
        timeManager();
    }

    void move()
    {
        position = rb.position;

        position.x += speed * direction * Time.deltaTime;

       
        anim.SetBool("isMoving", true);
        enemy.flipX = (direction != 1);

        if(direction==1)
            hitbox.offset = new Vector2(hitbox.size.x / 2, 0); 
        
        else
            hitbox.offset = new Vector2(-hitbox.size.x / 2, 0);

        rb.MovePosition(position);

    }

    void timeManager()
    {
        if (movingTime < 0)
        {
            movingTime = timeChange;
            direction = -direction;
            hitbox.enabled = true;
            anim.SetBool("hasFlicked", false);
        }

        else if(hitbox.enabled)
        {
            move();
            movingTime -=  Time.deltaTime;
        }

        else
        {
            movingTime -= Time.deltaTime;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInfo player = collision.gameObject.GetComponent<PlayerInfo>();

        if(player != null && player.isTricking)
        {
            if (!player.IsActionDoing())
            {
                player.AddStress(player.incrementStressValueByTick * player.onSightTickMultiplier);
                hitbox.enabled = false;
                movingTime = timeOut;
                anim.SetBool("hasFlicked", true);
            }
            else
            {
                player.GetComponent<TrickController>().OnDetected();
            }
        }
        
    }
}
