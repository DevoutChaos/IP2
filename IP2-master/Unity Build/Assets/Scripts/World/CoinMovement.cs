using UnityEngine;
using System.Collections;

public class CoinMovement : MonoBehaviour {
		
	public bool moveUp;
		
	public float max = 2f;
	public float move = 3f;
		
	public float yPos;
		
	Vector3 coinPos;
	Vector3 maxPos;
		
	// Use this for initialization
	void Start()
	{
	}
		
	// Update is called once per frame
	void Update()
	{
		coinPos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
		maxPos = new Vector3(this.transform.position.x, 1, 0);
			
		if (this.transform.position.y >= (yPos + 1))
		{
			moveUp = false;
		}
		else if (this.transform.position.y <= (yPos - 1))
		{
			moveUp = true;
		}
			
		if (moveUp)
		{
			transform.Translate(0, 1 * Time.deltaTime * move, 0);
		}
		if (!moveUp)
		{
			transform.Translate(0, -1 * Time.deltaTime * move, 0);
		}
	}
}