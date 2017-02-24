using UnityEngine;
using System.Collections;

public class MechaControl : MonoBehaviour 
{

	public Rigidbody rig = new Rigidbody();
	public int health;
	public int tankers;
	private bool current_tanker;
	private int tanker1;
	private int tanker2;
	private Vector3 pos;
	public float movement_speed;
	public float rotation_speed;
	private float angle;
	public Missile missile;
	public int reload;
	private int reloadMissile = 0;

	void Start () 
	{
		tanker1 = tankers;
		tanker2 = tankers;
	}

	void Update () 
	{
		Is_Dead ();
		TankersManager ();
		Move ();
		Rotation ();
		reloadMissile--;
	}

	void Move ()
	{
		if ((current_tanker && tanker1 > 0) || (!current_tanker && tanker2 > 0))
		{
			pos = rig.transform.position;
			float rad = ((Mathf.PI) / 180) * angle;
			float cos = Mathf.Cos(rad);
			pos.z += movement_speed * (Input.GetAxis ("Horizontal2") * cos + Input.GetAxis ("Horizontal") * Mathf.Cos ((Mathf.PI / 2) + rad ));
			pos.x += movement_speed * (Input.GetAxis ("Horizontal2") * Mathf.Cos ((Mathf.PI / 2) - rad) + Input.GetAxis("Horizontal") * cos);
			rig.transform.position = pos;
			if (Input.GetAxis ("Horizontal2") != 0 || Input.GetAxis("Horizontal") != 0)
			{
				if (current_tanker)
					tanker1--;
				else
					tanker2--;
			}
		}
	}

	void Rotation()
	{
		angle += rotation_speed * Input.GetAxis("Rotation");
		rig.transform.rotation = Quaternion.Euler(0, angle, 0);
	}

	public void Shoot()
	{
		if (reloadMissile <= 0)
		{
			Instantiate (missile, rig.position, rig.rotation);
			reloadMissile = reload;
		}
	}

	public void Is_Shot()
	{
		health -= 25;
	}

	void TankersManager ()
	{
		if (current_tanker)
		{
			if (tanker2 < tankers)
				tanker2++;
			if (tanker1 <= 0)
				current_tanker = false;
			}
		else
		{
			if (tanker1 < tankers)
				tanker1++;
			if (tanker2 <= 0)
				current_tanker = true;
		}
		Debug.Log ("tanker 1: " + tanker1.ToString() + ", tanker 2: " + tanker2.ToString());
	}

	void Is_Dead()
	{
		if (health <= 0)
			Destroy (this);
	}
}
