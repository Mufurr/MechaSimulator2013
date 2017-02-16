using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public Camera cam;
	public float rotation;
	private float angle_x;
	private float angle_y;
	private Vector2 center = new Vector2 ((Screen.width / 2), (Screen.height / 2));

	void Start () 
	{}
	
	void Update () 
	{
		Move ();
	}

	void Move ()
	{
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		angle_x += rotation * (center.y - y) * Time.deltaTime;
		if (angle_x < -90)
			angle_x = -90;
		if (angle_x > 90)
			angle_x = 90;
		angle_y += rotation * (x - center.x) * Time.deltaTime;
		cam.transform.rotation = Quaternion.Euler (angle_x, angle_y, 0);
	}
}
