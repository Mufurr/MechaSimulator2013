using UnityEngine;
using System.Collections;

public class EnergySword : MonoBehaviour {

	private Transform Trans;
	private Vector3 scale;
	private Vector3 pos;
	private bool on;

	void Start () 
	{
		Trans = GetComponent<Transform> ();
		scale = new Vector3 (6, 1.5F, 0);
		pos = Vector3.back;
		on = false;
	}
	
	void Update () 
	{
		if (on && (scale.z < 2))
		{
			scale.z += 0.25F;
			pos.z += 0.25F;
			Trans.localScale = scale;
			Trans.localPosition = pos;
		}
		if ((!on) && (scale.z > 0))
		{
			scale.z -= 0.25F;
			pos.z -= 0.25F;
			Trans.localScale = scale;
			Trans.localPosition = pos;
		}
			
	}

	public void Switch ()
	{
		on = !on;
	}
}
