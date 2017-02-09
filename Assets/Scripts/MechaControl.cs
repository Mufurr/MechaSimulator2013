using UnityEngine;
using System.Collections;

public class MechaControl : MonoBehaviour 
{

	public Rigidbody rig = new Rigidbody();
	private Vector3 pos;
	public float speed;
	public float rotation;
	public float angle;

	void Start () 
	{}

	void Update () 
	{
		pos = rig.transform.position;
		Move ();
		Rotation ();
		rig.transform.position = pos;

	}

	void Move ()
	{
		pos.x += speed * Input.GetAxis ("Horizontal");
		pos.z += speed * Input.GetAxis ("Horizontal2");
	}

	void Rotation()
	{
		angle += rotation * Input.GetAxis("Rotation");
		transform.rotation = Quaternion.Euler(0, angle, 0);
	}
}
