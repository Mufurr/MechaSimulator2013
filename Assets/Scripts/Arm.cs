using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

	public bool rightArm;
	public Shoulder shoulder;
	public Elbow elbow;
	public int health { get; private set; }
	private float max;
	private float min;

	void Start () 
	{
		health = 100;
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
		if (health >= 0) 
		{
			shoulder.Move (min, max);
			if ((shoulder.angley <= min) || (shoulder.angley >= max)) 
			{
				elbow.Move (min, max);
			}
		}
	}

	/*void OnTriggerEnter (Collider other)
	{
		Physics.IgnoreLayerCollision (8, 10);
		if (other.tag == "Explosion") {
			health -= 10;
			Debug.Log ("Arm damaged");
		}
	}*/
}
