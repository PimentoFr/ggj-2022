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
		left,
		interact
	}
	public GameObject pausing;
	public float moveSpeedNormal = 2;
	public float moveSpeedChaos = 2;
	private Direction direction = Direction.right;
	public KeyCode leftKey = KeyCode.Q;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode swapHumorKey = KeyCode.A;
	public KeyCode interactKey = KeyCode.Space;
	//replace with animation ?
	public Sprite normalSprite;
	public Sprite chaosSprite;

    //Suivi Camera
    public GameObject poissonPilote_GO;
    public float piloteCamSpeed = 0.5f;
    public float piloteCamIdleSpeed = 0.2f;
	//Variable qui d�finit que le joueur est en train de "saboter" quelque chose, sert a activer les alertes visuelles et a dire aux PNJ qu'il peuvent le "griller"

	private MoveState prevMoveState = MoveState.idle;
	private MoveState moveState = MoveState.right;
	private Vector2 m_velocity = new Vector2();
	private Interactable m_callback = null;

	private Rigidbody2D m_rigidbody;
	private SpriteRenderer m_spriteRenderer;
	private Collider2D m_collider;
	private Animator m_anim;

	private PlayerInfo m_playerInfo;


	// Start is called before the first frame update
	void Start()
	{
		m_spriteRenderer = GetComponent<SpriteRenderer>();
		m_rigidbody = GetComponent<Rigidbody2D>();
		m_anim = GetComponent<Animator>();
		m_playerInfo = GetComponent<PlayerInfo>();
		m_rigidbody.velocity = new Vector2(0,0);
		m_velocity.x = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if(!pausing.GetComponent<Pause>().getPaused())
        {
			//update moveState tmp
			handleInput();
			//update states
			handleMoveStateChange();
		}
		
	}

	void FixedUpdate()
	{
		
		if (!pausing.GetComponent<Pause>().getPaused())
			move();

        camFollow();
		animate();
	}
	
	public void interact(bool value)
	{
		if(value)
		{
			moveState = MoveState.interact;
		}
		else
		{
			moveState = prevMoveState;
		}
	}

	void handleInput()
	{
		//get state
		bool left = Input.GetKey(leftKey);
		bool right = Input.GetKey(rightKey);
		//get if pressed
		bool interact = Input.GetKeyDown(interactKey);
		bool swapHumor = Input.GetKeyDown(swapHumorKey);

		// 2 keys = idle
		if(moveState != MoveState.interact)
		{
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
			///
			if(swapHumor)
			{
				handleSwapHumor();
			}
		}
		

		if (interact)
		{
			handleInteraction();
		}
		
	}

	void move()
	{
		if(moveState != MoveState.interact && moveState != MoveState.idle )
		{
			float moveSpeed = m_playerInfo.GetIsTricking() ? moveSpeedChaos : moveSpeedNormal;
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
		m_anim.SetBool("isMoving", moveState != MoveState.idle && (moveState != MoveState.interact));
		m_anim.SetBool("isChaos", m_playerInfo.GetIsTricking());
		m_spriteRenderer.flipX = (direction == Direction.left);
	}

    void camFollow()
    {
        switch (moveState)
        {
            case MoveState.right:
                poissonPilote_GO.transform.localPosition = new Vector2(Mathf.Clamp(poissonPilote_GO.transform.localPosition.x + piloteCamSpeed,-6f,6f), poissonPilote_GO.transform.localPosition.y);
                break;
            case MoveState.left:
                poissonPilote_GO.transform.localPosition = new Vector2(Mathf.Clamp(poissonPilote_GO.transform.localPosition.x - piloteCamSpeed, -6f, 6f), poissonPilote_GO.transform.localPosition.y);
                break;

            case MoveState.idle:
                if (poissonPilote_GO.transform.localPosition.x < 0f)
                {
                    poissonPilote_GO.transform.localPosition = new Vector2(Mathf.Clamp(poissonPilote_GO.transform.localPosition.x + piloteCamIdleSpeed, -6f, 0f), poissonPilote_GO.transform.localPosition.y);
                }
                else if (poissonPilote_GO.transform.localPosition.x > 0f)
                {
                    poissonPilote_GO.transform.localPosition = new Vector2(Mathf.Clamp(poissonPilote_GO.transform.localPosition.x - piloteCamIdleSpeed, 0f, 6f), poissonPilote_GO.transform.localPosition.y);
                }
                break;
        }

    }

	void handleMoveStateChange()
	{

		if (moveState != MoveState.interact)
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
	}

	void handleInteraction()
	{
		if(m_callback)
		{
			m_callback.handleInteraction(m_playerInfo.GetIsTricking());
		}
	}

	void handleSwapHumor()
    {
		m_playerInfo.ToggleIsTricking();
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

	public void setInteractionCallback(Interactable callback)
	{
		m_callback = callback;
	}
}
