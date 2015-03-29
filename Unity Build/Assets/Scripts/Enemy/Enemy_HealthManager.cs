using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy_HealthManager : MonoBehaviour
{

	//Declarations
	public int enemyHealth = 100;
	public Slider healthSlider;
	public GameObject self;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		healthSlider.value = enemyHealth;
	}

	public void EnemyDamage (int damage)
	{
		// Health - damage
		enemyHealth -= damage;
		// If the enemt's health is less than 0, kill them
		if (enemyHealth <= 0) {
			GameMaster.KillEnemy (this);
			Debug.Log ("Killed enemy");
		}
		
	}
}
