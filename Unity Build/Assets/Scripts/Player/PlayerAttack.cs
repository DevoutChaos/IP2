using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject target;

	// Declerations
	Enemy_HealthManager enemy;
	public BoxCollider2D hitPoint;

	public int attackStrength;

	public float delay;
	
	private bool facingRight = false;
	private bool attacking = false;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Disable hitbox so it isn't constantly attacking
		hitPoint.enabled = false;
		// If the player presses F, Attack
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			Attack ();
			StartCoroutine (Cooldown ());
		}
	}
	
	private void Attack()
	{
		hitPoint.enabled = true;
		// If the player hit box doesn't collide with an enemy, ignore it 
		enemy = (Enemy_HealthManager)target.GetComponent<Enemy_HealthManager> ();
		if (enemy == null)
			return;
		
		// Damage enemy
		enemy.EnemyDamage (attackStrength);
		Debug.Log ("Did " + attackStrength + " to Enemy!");
	}
	
	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds (delay);
		hitPoint.enabled = false;
	}
}
