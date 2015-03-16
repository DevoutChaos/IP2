using UnityEngine;
using System.Collections;

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
