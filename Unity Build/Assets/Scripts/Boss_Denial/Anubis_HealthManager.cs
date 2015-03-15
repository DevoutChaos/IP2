using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Anubis_HealthManager : MonoBehaviour
{
	/*Instructions
	 * Attach to Anubis (parent) 
	 * May need to change value of "enemyHealth" to suit
	 * Don't touch booleans
	 * Attach the healthSlider from the canvas
	 */

	//Declarations
	public int enemyHealth = 100;
	public Slider healthSlider;
	public GameObject self;
	public Anubis_Movement_AI anubisMovement;

	//Intermission Booleans
	private bool triggered66 = false;
	private bool triggered33 = false;
	private bool triggered05 = false;

	private bool takingDamage = false;
	
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemyHealth <= 66 && triggered66 == false) {
			triggered66 = true;
			anubisMovement.shouldSpeAtt = true;
		}

		if (enemyHealth <= 33 && triggered33 == false) {
			triggered33 = true;
			anubisMovement.shouldSpeAtt = true;
		}

		if (enemyHealth <= 5 && triggered05 == false) {
			triggered05 = true;
			anubisMovement.shouldSpeAtt = true;
		}

		healthSlider.value = enemyHealth;
	}
	
	public void EnemyDamage (int damage)
	{
		takingDamage = true;
		
		// Health - damage
		enemyHealth -= damage;
		// If the enemt's health is less than 0, kill them
		if (enemyHealth <= 0) {
			GameMaster.KillEnemy (this);
			Debug.Log ("Killed Anubis");
		}
		
	}
}
