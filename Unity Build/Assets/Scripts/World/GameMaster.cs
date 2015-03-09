using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour 
{

	public static GameMaster gameMaster;
	
	public Transform playerPrefab;
	public Transform spawnPoint;
	public int delay = 2;
	
	// Use this for initialization
	void Start () 
	{
		if (gameMaster == null) 
		{
			gameMaster = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}
		
	}
	
	/*public IEnumerator PlayerRespawn()
	{
		yield return new WaitForSeconds (delay);
		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}*/
	
	public static void KillPlayer(Player player)
	{
		Destroy (player.gameObject);
		//gameMaster.StartCoroutine (gameMaster.PlayerRespawn());
	}

	public static void KillEnemy(Enemy_HealthManager enemy)
	{
		Destroy (enemy.gameObject);
	}
}
