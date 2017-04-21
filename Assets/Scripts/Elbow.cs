using UnityEngine;
using System.Collections;

public class Elbow : MonoBehaviour 
{

	private Transform Trans;
	private float angley;

	void Start () 
	{
		Trans = GetComponent<Transform> ();
		angley = 0;
	}

	public void Move (float min, float max)
	{
		angley += 2 * Input.GetAxis ("Horizontal");
		if (angley < min)
			angley = min;
		if (angley > max)
			angley = max;
		Trans.localRotation = Quaternion.Euler (0, angley, 90);
	}

}