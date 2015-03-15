using UnityEngine;
using System.Collections;

public class Anubis_Movement_AI : MonoBehaviour
{
	/*Instructions
	 * Attach to Anubis (parent)
	 * Set public variables for Speed (maxSpeed and vertSpeed)
	 * Don't touch booleans
	 * Attach Player object to "GameObject player"
	 * Animations are still required, Anubis' Special Attack will be implemented once an animation is available
	 */


	//Declarations
	public float maxSpeed = 5f;
	public float vertSpeed = 5f;
	public float move = 1f;
	public float vertMove = 1f;
	public bool moveRight = true;
	private bool facingRight = true;

	public Vector2 playerPosition;
	GameObject player;
	public float range = 1.0f;

	public bool shouldSpeAtt = false;
	
	//Animator
	Animator anim;

	//Initialisation
	void Start ()
	{
		//Set-up for Animator
		anim = GetComponent<Animator> ();
		
		//finds the "Player"
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (shouldSpeAtt == true) {
			AnubisSpecialAttack ();
			shouldSpeAtt = false;
		} else {
			AnubisAggro ();
		}
	}

	void AnubisSpecialAttack ()
	{

	}

	void AnubisAggro ()
	{
		//Checks for the position of the player
		playerPosition = new Vector2 (player.transform.position.x, player.transform.position.y);
		float relativePos = player.transform.position.x - transform.position.x;

		if (player.transform.position.y > transform.position.y) {
			vertMove = 0f;
			vertMove++;
		} else if (player.transform.position.y < transform.position.y) {
			vertMove = 0f;
			vertMove--;
		} else if (relativePos <= range) {
			//Possible Issue -> Vertical Movement will prevent attacks, vertSpeed should be very high
			move = 0f;
			//Attack Animation
		} else if (player.transform.position.x > transform.position.x) {
			move = 0f;
			move++;
		} else if (player.transform.position.x < transform.position.x) {
			move = 0f;
			move--;
		}
	}

	void FixedUpdate ()
	{
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		// Allows animations using speed paramater
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, vertMove * vertSpeed);
		
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
}
