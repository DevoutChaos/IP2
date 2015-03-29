using UnityEngine;
using System.Collections;

public class Enemy_LoS : MonoBehaviour
{
	//Declarations
	public Transform sightStart;
	public Transform sightEnd;
	public bool canDetectPlayer = false;
	public Enemy_Reg_AI enemyController;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Raycasting ();
		Behaviour ();
	}

	void Raycasting ()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.yellow);
		canDetectPlayer = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Player"));
	}

	void Behaviour ()
	{
		if (canDetectPlayer) {
			enemyController.patrolling = false;
			enemyController.aggro = true;
		}
	}
}
