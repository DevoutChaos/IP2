using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour 
{

	// Array of all back/foregrounds
	public Transform[] backgrounds;
	// How much the camera moves in relation to the backgrounds
	private float[] parallaxScales;
	// How smooth the parallax is going to be
	public float smoothing = 1f;
	// Reference to the main cameras transform
	private Transform cam;
	// the position of the camera in the previous frame
	private Vector3 previousCamPos;	
	
	// Great for references.
	void Awake () {
		// ref to camera
		cam = Camera.main.transform;
	}
	
	// Use this for initialization
	void Start () {
		// Previous frame at current camera position
		previousCamPos = cam.position;
		
		// Assigning coresponding parallaxScales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		for (int i = 0; i < backgrounds.Length; i++) {
			// Opposite of camera movement
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
			
			// Set target x position
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;
			
			// Create target position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
			
			// Fade from current to target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		
		// Previous frame at current camera position
		previousCamPos = cam.position;
	}
}
