using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
	public enum Direction : int
	{
		right = 1,
		left = -1
	}
	public enum MoveState
	{
		idle,
		right,
		left
	}

	public float moveSpeed = 2;
	public Direction direction = Direction.right;
	public KeyCode leftKey = KeyCode.Q;
	public KeyCode rightKey = KeyCode.D;

	private bool isMoving = false;
	private MoveState prevMoveState = MoveState.idle;
	private MoveState moveState = MoveState.right;
	//direction dans laquelle le player est oriente
	
	private Vector2 m_velocity = new Vector2();

	Rigidbody2D m_rigidbody2D;
	SpriteRenderer m_sprite;
	// Start is called before the first frame update
	void Start()
	{
		m_sprite = GetComponent<SpriteRenderer>();
		m_rigidbody2D = GetComponent<Rigidbody2D>();
		m_rigidbody2D.velocity = new Vector2(0,0);
		m_velocity.x = 0;
	}

	// Update is called once per frame
	void Update()
	{
		//update moveState tmp
		handleInput();
		//update states
		handleMoveStateChange();
	}

	void FixedUpdate()
	{
		//update sprite flipness
		m_sprite.flipX = (Direction.right == direction);
		animate();
		move();

		
	}

	void handleInput()
	{
		bool left = Input.GetKey(leftKey);
		bool right = Input.GetKey(rightKey);
		// 2 keys = idle
		if(!(right ^ left))
		{
			moveState = MoveState.idle;
		}
		else if(right)
		{
			moveState = MoveState.right;
		}
		else if(left)
		{
			moveState = MoveState.left;
		}
		Debug.Log(moveState);
		
	}

	void move()
	{
		if(isMoving)
		{
			m_velocity.x = moveSpeed * (int)direction;
		}
		else
		{
			m_velocity.x = 0;
		}
		m_rigidbody2D.velocity = m_velocity;
	}

	void animate()
	{
		//set animation state
		if(isMoving)
		{
			//toDo animation walk
		}
		else
		{
			//toDo animation idle
		}
	}

	void handleMoveStateChange()
	{
		if(moveState != prevMoveState)
		{
			switch(moveState)
			{
				case MoveState.right :
					direction = Direction.right;
					isMoving = true;
					break;
				case MoveState.left :
					direction = Direction.left;
					isMoving = true;
					break;
				case MoveState.idle :
					isMoving = false;
					break;
			}
			prevMoveState = moveState;
		}
	}
}
