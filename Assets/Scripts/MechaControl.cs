using UnityEngine;
using System.Collections;

public class MechaControl : MonoBehaviour 
{

	public Rigidbody rig = new Rigidbody();
	private int health;
	private bool currentTanker;
	private int tanker1;
	private int tanker2;
	private Vector3 pos;
	private float angle;
	public Missile missile;
	private int ammo;
	private int reload;
	private int reloadMissile = 0;

	void Start () 
	{
		health = 100;
		ammo = 15;
		tanker1 = 100;
		tanker2 = 100;
		reload = 50;
	}

	void Update () 
	{
		IsDead ();
		TankersManager ();
		Rotation ();
		Move ();
		reloadMissile--;
		Debug.Log ("Health: " + health + "hp; Tanker 1: " + tanker1 + "; Tanker 2: " + tanker2 + "; Ammo: " + ammo);
	}

	void Move ()
	{
		if ((currentTanker && tanker1 > 0) || (!currentTanker && tanker2 > 0))
		{
			pos = rig.transform.position;
			float rad = ((Mathf.PI) / 180) * angle;
			float cos = Mathf.Cos(rad);
			pos.z += 0.1F * (Input.GetAxis ("Horizontal2") * cos + Input.GetAxis ("Horizontal") * Mathf.Cos ((Mathf.PI / 2) + rad ));
			pos.x += 0.1F * (Input.GetAxis ("Horizontal2") * Mathf.Cos ((Mathf.PI / 2) - rad) + Input.GetAxis("Horizontal") * cos);
			rig.transform.position = pos;
			if (Input.GetAxis ("Horizontal2") != 0 || Input.GetAxis("Horizontal") != 0)
			{
				if (currentTanker)
					tanker1--;
				else
					tanker2--;
			}
		}
	}

	void Rotation()
	{
		angle += Input.GetAxis("Rotation");
		rig.transform.rotation = Quaternion.Euler(0, angle, 0);
	}

	public void Shoot()
	{
		if (ammo > 0 && reloadMissile <= 0)
		{
			Instantiate (missile, rig.position, rig.rotation);
			ammo--;
			reloadMissile = reload;
		}
	}

	void TankersManager ()
	{
		if (currentTanker)
		{
			if (tanker2 < 100)
				tanker2++;
			if (tanker1 <= 0)
				currentTanker = false;
			}
		else
		{
			if (tanker1 < 100)
				tanker1++;
			if (tanker2 <= 0)
				currentTanker = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Heal")
		{
			health += 50;
			if (health >= 100)
				health = 100;
			ammo += 15;
			if (ammo >= 15)
				ammo = 15;
		}

		if (other.tag == "Explosion")
			health -= 20;
	}

	void IsDead()
	{
		if (health <= 0)
			Destroy (rig.gameObject);
	}

	public void Switch_Tanker()
	{
		currentTanker = !currentTanker;
	}
}
