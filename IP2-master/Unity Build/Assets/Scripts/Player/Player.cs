using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Player.
/// Sets up and assigns value for healthbar
/// Allows player to take damage
/// </summary>


public class Player : MonoBehaviour 

{

	// Minimum y position the player can be at without dying
	public int fallBoundary = -20;
	
	// Healthbar variables
	public Slider healthSlider;
	public GameObject self;
	
	// Health variables
	public int health;

	// Damage cooldown variables
	private bool takingDamage = false;
	private bool onCooldown = false;
	public int cooldownDelay = 1;
	
	// Player's boxcollider
	public BoxCollider2D boxcollider;
	
	void Start ()
	{
		health = 100;
	}
	
	// Update is called once per frame
	void Update ()
	{

		healthSlider.value = health;
		// If the player falls below the boundary, they take 1792 damage
		if (transform.position.y <= fallBoundary) {
			PlayerDamage (1792);
		}
		
		// Update the healthbar
		if (takingDamage == true) {
			takingDamage = false;
		}
	
	}
	
	public void PlayerDamage (int damage)
	{
		takingDamage = true;
		
		// Disable the box collider so the player doesn't take double damage
		boxcollider.enabled = false;
		// Start a cooldown period so the player doesn't keep taking damage
		if (!onCooldown && health > 0) {
			StartCoroutine (Cooldown ());
		}
		
		// Health - damage
		health -= damage;

		// If the player's health is less than 0, kill them
		if (health <= 0) {
			GameMaster.KillPlayer (this);
			Debug.Log ("WASTED");
		}

		Debug.Log ("Health = " + health);

		
	}
	
	// Cooldown after damage so player doesn't take double damage
	IEnumerator Cooldown ()
	{
		// Wait and then re enable collider
		yield return new WaitForSeconds (cooldownDelay);
		boxcollider.enabled = true;
	}




}
