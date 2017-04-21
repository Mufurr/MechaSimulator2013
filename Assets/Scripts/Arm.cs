using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

	public bool rightArm;
	public Shoulder shoulder;
	public Elbow elbow;
	private float max;
	private float min;

	void Start () 
	{
		if (rightArm)
		{
			min = -90;
			max = 0;
		}
		else
		{
			min = 0;
			max = 90;
		}
	}
	
	public void Move () 
	{
		shoulder.Move (min, max);
		if ((shoulder.angley <= min + 0.05F) || (shoulder.angley >= max - 0.05F))
		{
			Debug.Log (shoulder.angley.ToString() + ", min =" + min.ToString());
			elbow.Move (min, max);
		}
	}
}
