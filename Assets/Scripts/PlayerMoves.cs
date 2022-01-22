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

	public float moveSpeedNormal = 2;
	public float moveSpeedChaos = 2;
	public Direction direction = Direction.right;
	public KeyCode leftKey = KeyCode.Q;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode interactKey = KeyCode.Space;
	//replace with animation ?
	public Sprite normalSprite;
	public Sprite chaosSprite;

	private bool isChaos = false;
	private float moveSpeed;
	private MoveState prevMoveState = MoveState.idle;
	private MoveState moveState = MoveState.right;
	private Vector2 m_velocity = new Vector2();
	private Interactable m_callback = null;

	private Rigidbody2D m_rigidbody;
	private SpriteRenderer m_spriteRenderer;
	private Collider2D m_collider;
	private Animator m_anim;

	// Start is called before the first frame update
	void Start()
	{
		m_spriteRenderer = GetComponent<SpriteRenderer>();
		m_rigidbody = GetComponent<Rigidbody2D>();
		m_anim = GetComponent<Animator>();
		m_rigidbody.velocity = new Vector2(0,0);
		m_velocity.x = 0;
		setChaos(false);
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
		animate();
		move();
	}

	void handleInput()
	{
		//get state
		bool left = Input.GetKey(leftKey);
		bool right = Input.GetKey(rightKey);
		//get if pressed
		bool interact = Input.GetKeyDown(interactKey);

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

		if (interact)
		{
			handleInteraction();
		}
	}

	void move()
	{
		if(moveState != MoveState.idle)
		{
			m_velocity.x = moveSpeed * (int)direction;
		}
		else
		{
			m_velocity.x = 0;
		}
		m_rigidbody.velocity = m_velocity;
	}

	void animate()
	{
		//set animation state
		m_anim.SetBool("isMoving", moveState != MoveState.idle);
		m_anim.SetBool("isChaos", isChaos);
		m_spriteRenderer.flipX = (direction == Direction.left);
	}

	void handleMoveStateChange()
	{
		if(moveState != prevMoveState)
		{
			switch(moveState)
			{
				case MoveState.right :
					direction = Direction.right;
					break;
				case MoveState.left :
					direction = Direction.left;
					break;
				case MoveState.idle :
					break;
			}
			prevMoveState = moveState;
		}
	}

	public void setChaos(bool chaos)
	{
		isChaos = chaos;

		if(chaos)
		{
			m_spriteRenderer.sprite = chaosSprite;
			moveSpeed = moveSpeedChaos;
		}
		else
		{
			m_spriteRenderer.sprite = normalSprite;
			moveSpeed = moveSpeedNormal;
		}
	}

	void handleInteraction()
	{
		if(m_callback)
		{
			m_callback.handleInteraction(isChaos);
		}
	}

	public void setInteractionCallback(Interactable callback)
	{
		m_callback = callback;
	}
}
