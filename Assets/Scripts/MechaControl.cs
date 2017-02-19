using UnityEngine;
using System.Collections;

public class MechaControl : MonoBehaviour 
{

	public Rigidbody rig = new Rigidbody();
	private Vector3 pos;
	public Missile missile;
	public float speed;
	public float rotation;
	private float angle;
	private int reloadMissile = 0;

	void Start () 
	{}

	void Update () 
	{
		Move ();
		Rotation ();
		reloadMissile--;
	}

	void Move ()
	{
		pos = rig.transform.position;
		float rad = ((Mathf.PI) / 180) * angle;
		float cos = Mathf.Cos(rad);
		pos.z += speed * (Input.GetAxis ("Horizontal2") * cos + Input.GetAxis ("Horizontal") * Mathf.Cos ((Mathf.PI / 2) + rad ));
		pos.x += speed * (Input.GetAxis ("Horizontal2") * Mathf.Cos ((Mathf.PI / 2) - rad) + Input.GetAxis("Horizontal") * cos);
		rig.transform.position = pos;
	}

	void Rotation()
	{
		angle += rotation * Input.GetAxis("Rotation");
		rig.transform.rotation = Quaternion.Euler(0, angle, 0);
	}

	public void Shoot()
	{
		if (reloadMissile <= 0)
		{
			Instantiate (missile, rig.position, rig.rotation);
			reloadMissile = 50;
		}
	}
}
