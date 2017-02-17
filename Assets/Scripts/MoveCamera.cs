using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour 
{

	public Camera cam;
	private float angle_x;
	private float angle_y;

	void Start () 
	{}
	
	void Update () 
	{
		Move ();
	}

	void Move ()
	{
		angle_x += Input.GetAxis("Mouse y") * Time.deltaTime;
		if (angle_x < -90)
			angle_x = -90;
		if (angle_x > 90)
			angle_x = 90;
		angle_y += Input.GetAxis("Mouse x") * Time.deltaTime;
		cam.transform.rotation = Quaternion.Euler (angle_x, angle_y, 0);
	}
}
