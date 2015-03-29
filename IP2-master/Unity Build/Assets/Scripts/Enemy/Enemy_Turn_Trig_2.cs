
using UnityEngine;
using System.Collections;

public class Enemy_Turn_Trig_2 : MonoBehaviour 
{
	
	//Declarations
	public Enemy_Reg_AI enemyController;
	
	//Initialisation
	void Start () 
	{
		
	}
	
	//Call Update once per frame
	void Update () 
	{
		
	}
	
	void FixedUpdate () 
	{
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		//Debug.Log ("Something is also here");
		if(other.gameObject.tag!="Player")
		{
			enemyController.moveRight = true;
		}
	}
}

