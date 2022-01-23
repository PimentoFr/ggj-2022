using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJController : MonoBehaviour
{
    public float speed;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1, prevDirection;


    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        prevDirection = direction;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        timer -=  Time.deltaTime;

        if (timer < 0)
        {
            moveHandler();
            timer = changeTime;
        }

        animate();

        Vector2 position = rigidbody2D.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        

        rigidbody2D.MovePosition(position);
    }

    void animate()
    {
        if (direction != 0)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);

        spriteRenderer.flipX = (direction == -1);
    }

    void moveHandler()
    {
        if (direction != 0)
            direction = 0;
        else
        {
            direction = -prevDirection;
            prevDirection = direction;
        }
    }
}