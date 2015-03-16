using UnityEngine;
using System.Collections;

/// <summary>
/// Points.
/// Assigns points to wahtever object this script is added to
/// destroys object when collected
/// </summary>

public class Points : MonoBehaviour {

	public int pointsToAdd;
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null) 
			return;
		
		ScoreManager.AddPoints(pointsToAdd);
		
		Destroy (gameObject);
	}
}
