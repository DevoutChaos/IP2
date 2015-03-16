using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{

	// Minimum y position the player can be at without dying
	public int fallBoundary = -20;
	
	// Healthbar variables
	public RectTransform healthbar;
	public Image healthbarColour;
	
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
		// Healthbar y position
		YPos = healthbar.localPosition.y;
		// Healthbar at 100% position
		maxXPos = healthbar.localPosition.x;
		// Healthbar at 0 position
		minXPos = healthbar.localPosition.x - healthbar.rect.width;
		
		onCooldown = false;
		takingDamage = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// If the player falls below the boundary, they take 1792 damage
		if (transform.position.y <= fallBoundary) 
		{
			PlayerDamage (1792);
		}
		
		// Update the healthbar
		if (takingDamage = true) 
		{
			HandleHealth ();
			takingDamage = false;
		}
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
	
	private void HandleHealth()
	{
		// Get the current position of the healthbar
		float currentXValue = MapValues (health, 0, maxHealth, minXPos, maxXPos);
		// Move the healthbar to it's current posistion
		healthbar.transform.localPosition = new Vector3 (currentXValue, YPos);
		// Change the colour of the healthbar. From 100 it will go from green to red 
		if (health >= maxHealth / 2) 
		{
			healthbarColour.color = new Color32 ((byte)MapValues (health, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255); 
		} else
			healthbarColour.color = new Color32 (255, (byte)MapValues (health, 0, maxHealth / 2, 0, 255), 0, 255);
		
		
	}
	
	private float MapValues(float health, float minHealth, float maxHealth, float minXPos, float maxXPos )
	{
		// Translate health to a position
		return (health - minHealth) * (maxXPos - minXPos) / (maxHealth - minHealth) + minXPos; 
	}
}
