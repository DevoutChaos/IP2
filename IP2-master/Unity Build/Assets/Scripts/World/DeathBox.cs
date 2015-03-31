using UnityEngine;
using System.Collections;

public class DeathBox : MonoBehaviour {

	Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag=="Player")
		{
			//health = 0;
			Debug.Log("Player Died"+ other.gameObject.tag);
			player.PlayerDamage (100);
		}
	}
}
