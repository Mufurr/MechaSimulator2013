using UnityEngine;
using System.Collections;

public class MechaControl : MonoBehaviour 
{

	public Rigidbody rig = new Rigidbody();
	private Vector3 pos;
	private Quaternion rotn;
	public float speed;
	public float rotation;

	void Start () 
	{}

	void Update () 
	{
		pos = rig.transform.position;
		rotn = rig.transform.rotation;
		Move ();
		Rotation ();
		rig.transform.position = pos;
		rig.transform.rotation = rotn;
	}

	void Move ()
	{
		pos.x += speed * Input.GetAxis ("Horizontal");
		pos.z += speed * Input.GetAxis ("Horizontal2");
	}

	void Rotation()
	{
		rotn.y += rotation * Input.GetAxis ("Rotation");
	}
}
