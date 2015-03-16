using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Score manager.
/// Displays player score
/// allows points to be added
/// </summary>

public class ScoreManager : MonoBehaviour {

	public static int score;
	
	Text text;
	
	void Start()
	{
		text = GetComponent<Text>();
		
		score = 0;
	}
	
	void Update()
	{
		if (score <= 0) 
		{
			score = 0;
		}
		
		text.text = "" + score;
	}
	
	public static void AddPoints(int points)
	{
		score += points;
	}
}
