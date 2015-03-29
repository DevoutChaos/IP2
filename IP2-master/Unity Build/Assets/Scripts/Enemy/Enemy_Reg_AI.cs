
using UnityEngine;
using System.Collections;

public class Enemy_Reg_AI : MonoBehaviour
{
	
	//Declarations
	public float maxSpeed = 5f;
	public float move = 1f;
	public bool moveRight = true;
	private bool facingRight = true;

	public bool patrolling = true;
	public bool aggro = false;
	public Vector2 playerPosition;
	GameObject player;
	public float range = 1.0f;
	public float relativePos;

	//Animator
	Animator anim;

	//Animations
	public bool attack;

	//Check for ground
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	//Initialisation
	void Start ()
	{
		//Set-up for Animator
		anim = GetComponent<Animator> ();

		//finds the "Player"
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	//Call Update once per frame
	void Update ()
	{
		if (patrolling) {
			Patrol ();
		} else if (aggro) {
			Aggro ();
		}
	}

	void FixedUpdate ()
	{
		//Creates a circle beneath the enemy, returns true if the circle touches "ground"
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		// Allows animations using ground paramaters
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		// Allows animations using speed paramater
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		//Mirrors the animation depending on the facing direction
		if (move > 0 && facingRight == false) {
			Flip ();
		} else if (move < 0 && facingRight == true) {
			Flip ();			
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Patrol ()
	{
		if (moveRight == true) {
			move = 0f;
			move++;
		} else if (moveRight != true) {
			move = 0f;
			move--;
		}
	}

	void Aggro ()
	{
		//Checks for the position of the player
		playerPosition = new Vector2 (player.transform.position.x, player.transform.position.y);
		relativePos = player.transform.position.x - transform.position.x;

		if (0 < relativePos && relativePos < range) {
			move = 0f;
			//Attack Animation
			anim.SetBool ("Attack", attack);
		} else if (player.transform.position.x > transform.position.x && relativePos > range) {
			move = 0f;
			move++;
		} else if (player.transform.position.x < transform.position.x && relativePos < range) {
			move = 0f;
			move--;
		} 
	}
}
 
