using UnityEngine;
using System.Collections;

public class CoinPoints : MonoBehaviour 
{
	public int pointsToAdd;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null) 
			return;

		CoinsScoreManager.AddPoints(pointsToAdd);

		Destroy (gameObject);
	}
}
