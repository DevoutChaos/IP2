using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller.
/// Allows the player to move, jump and crouch
/// Assigns what the player can see as ground
<<<<<<< HEAD
=======
/// Allows player to climb any game object named "Ladder"
>>>>>>> master
/// </summary>

public class PlayerController : MonoBehaviour
{
	
	//General Declarations
	public float maxSpeed = 5f;
	private bool facingRight = true;
	public float jumpForce = 700f;
	
	//Animator
	Animator anim;
	
	//Check for ground
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	
	//Crouch
	public bool crouched = false;
	public float crouchSpeed = 2f;
	
	//Colliders
	public BoxCollider2D boxcollider;
	public CircleCollider2D circleCollider;

	// Ladder variables
	GameObject ladder;
	public bool isClimbing = false;
	public float climb;
	public float climbSpeed = 4;
	public float gravity = 2;

	// Use this for initialization
	void Start ()
	{	
		//Set-up for Animator
		anim = GetComponent<Animator> ();
		//Find Ladders
		ladder = GameObject.Find ("Ladder");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//Creates a circle beneath the player, returns true if the circle touches "ground"
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		// Allows animations using ground paramaters
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		float move = Input.GetAxis ("Horizontal");
		
		// Allows animations using speed paramater
		anim.SetFloat ("Speed", Mathf.Abs (move));
		// Sets crouch speed
		if (crouched) {
			rigidbody2D.velocity = new Vector2 (move * crouchSpeed, rigidbody2D.velocity.y);
		}
		//Sets the player in motion
		else
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		//Mirrors the animation depending on the facing direction
		if (move > 0 && facingRight == false) {
			Flip ();
		} else if (move < 0 && facingRight == true) {
			Flip ();
		}
	}
	
	void Update ()
	{
		// Sets Jump key and animation, also prevents double jump
		if (grounded && Input.GetButtonDown ("Jump")) 
		{
			//Makes sure the animation changes to an aerial one
			anim.SetBool ("Ground", false);
			//Applies the jump force
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		}
		
		anim.SetBool ("Crouch", crouched);
		// Crouches when key is pressed otherwise stands
		if (grounded && Input.GetButtonDown ("Fire3")) 
		{
			Crouch ();
		}
<<<<<<< HEAD
		
		if (grounded && crouched && Input.GetButtonUp ("Fire3")) {
=======
		if (grounded && crouched && Input.GetButtonUp ("Fire3")) 
		{
>>>>>>> master
			Stand ();
		}

		// Climb Ladder
		if (isClimbing) 
		{
			climb = Input.GetAxis ("Vertical");
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, climb * climbSpeed);
		}
	}
	
	// Sets crouch key and animation, disables top boxcollider
	private void Crouch ()
	{
		crouched = true;
		boxcollider.enabled = false;
	}
	// Re enables boxcollider when player stands
	private void Stand ()
	{
		crouched = false;
		boxcollider.enabled = true;
	}
	
	// Flips world to give impression of player going left
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	// Enter Ladder, turn gravity off
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == ladder) 
		{
			isClimbing = true;
			rigidbody2D.gravityScale = 0;
		}
	}

	// Exit Ladder, turn gravity back on
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == ladder) 
		{
			isClimbing = false;
			rigidbody2D.gravityScale = gravity;
		}
	}
}
