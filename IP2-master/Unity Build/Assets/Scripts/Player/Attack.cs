using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public int damageToGive;
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		// If it collides with something that isn't the player, it ignores it
		var enemy = other.GetComponent<Enemy_HealthManager> ();
		if (enemy == null)
			return;
		
		// Damage player
		enemy.EnemyDamage (damageToGive);
		Debug.Log ("Did " + damageToGive + " to player!");
	}
}
