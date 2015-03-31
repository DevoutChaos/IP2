using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	// Minimum y position the player can be at without dying
	public int fallBoundary = -20;
	
	// Healthbar variables
	public Slider playerHealth;
	
	// x and y positions for healthbar
	private float YPos;
	private float minXPos;
	private float maxXPos;
	
	// Health variables
	public int maxHealth = 100;
	public int health { get; private set;}
	
	// Damage cooldown variables
	private bool takingDamage;
	private bool onCooldown;
	public int cooldownDelay = 1;
	
	// Player's boxcollider
	public BoxCollider2D boxcollider;
	
	void Awake()
	{
		// Sets health
		health = maxHealth;
	}
	
	void Start()
	{	
		onCooldown = false;
		takingDamage = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerHealth.value = health;
	}
	
	public void PlayerDamage(int damage)
	{
		takingDamage = true;
		
		// Disable the box collider so the player doesn't take double damage
		boxcollider.enabled = false;
		// Start a cooldown period so the player doesn't keep taking damage
		if (!onCooldown && health > 0) 
		{
			StartCoroutine(Cooldown());
		}
		
		// Health - damage
		health -= damage;
		// If teh player's health is less than 0, kill them
		if (health <= 0) 
		{
			GameMaster.KillPlayer (this);
			Debug.Log ("WASTED");
		}
		
	}
	
	// Cooldown after damage so player doesn't take double damage
	IEnumerator Cooldown()
	{
		// Wait and then re enable collider
		yield return new WaitForSeconds (cooldownDelay);
		boxcollider.enabled = true;
	}

}
