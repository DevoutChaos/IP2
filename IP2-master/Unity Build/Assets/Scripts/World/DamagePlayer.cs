using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour 
{

	// Variables
	public int delay = 1;
	public int damageToGive;
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		// If it collides with something that isn't the player, it ignores it
		var player = other.GetComponent<Player> ();
		if (player == null)
			return;
		
		// Damage player
		player.PlayerDamage (damageToGive);
		Debug.Log ("Did " + damageToGive + " to player!");
	}
}
