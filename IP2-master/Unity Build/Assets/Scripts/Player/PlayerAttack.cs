using UnityEngine;
using System.Collections;

/// <summary>
/// Player attack.
/// Key "F" to attack
/// Allows the player to attack enemies (target), and sets up the attack animation
/// Once the "F" key is released, attacking ceases
/// </summary>
public class PlayerAttack : MonoBehaviour 
{
	
	public GameObject target;
	
	// Declerations
	Animator anim;
	
	public BoxCollider2D hitPoint;
	public bool attacking = false;
	
	// Use this for initialization
	void Start () 
	{
		// Set up animator
		anim = GetComponent<Animator> ();
		// Disable hitbox so it isn't constantly attacking
		hitPoint.enabled = false;
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Set up attack animation
		anim.SetBool ("Attack", attacking);
		// If the player presses F, Attack
		if (Input.GetKeyDown (KeyCode.F)) {
			// Set attack animation
			Attack ();
		} 
		else if (Input.GetKeyUp(KeyCode.F)) 
		{
			hitPoint.enabled = false;
			attacking = false;
		}
	}
	
	private void Attack()
	{
		hitPoint.enabled = true;
		attacking = true;

		/*// If the player hit box doesn't collide with an enemy, ignore it 
		enemy = (Enemy_HealthManager)target.GetComponent<Enemy_HealthManager> ();
		if (enemy == null)
			return;
		
		// Damage enemy
		enemy.EnemyDamage (attackStrength);
		Debug.Log ("Did " + attackStrength + " to Enemy!");*/
	}

}
