using UnityEngine;
using System.Collections;

public class Quit_Button : MonoBehaviour {

	public Texture2D texture = null;
	public Texture2D hoverTexture;
	public Texture2D currentTexture;

	public void Start()
	{
		currentTexture=texture;
	}

	IEnumerator PlayButtonClickPlay()
	{
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		Application.Quit();
	}

	private void OnGUI () {
		if(GUI.Button (new Rect(Screen.width /4 , Screen.height *3 /6 , texture.width, texture.height), currentTexture, GUIStyle.none)) {

			StartCoroutine(PlayButtonClickPlay());

		}
	}
	public void Update() {
		Rect boundingBox=new Rect(Screen.width /4 , Screen.height *3 /6 , currentTexture.width, currentTexture.height);
		Vector3 actualMousePosition = Input.mousePosition;
		actualMousePosition.y = Screen.height-Input.mousePosition.y;
		if (boundingBox.Contains(actualMousePosition)){
			//Input.mousePosition
			currentTexture=hoverTexture;
		}
		else
		{
			currentTexture=texture;
		}
	}
}
