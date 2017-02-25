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
	public Collider Flames;
	private bool flamethrower;

	void Start () 
	{
		health = 1000;
		ammo = 25;
		tanker1 = 1000;
		tanker2 = 1000;
		reload = 50;
		flamethrower = false;

	}

	void Update () 
	{
		IsDead ();
		TankersManager ();
		Rotation ();
		Move ();
		FlameThrower ();
		reloadMissile--;
		Debug.Log ("Health: " + health + "hp; Tanker 1: " + tanker1 + "; Tanker 2: " + tanker2 + "; Ammo: " + ammo);
	}

	void Move ()
	{
		if (TankerIsNotEmpty())
		{
			pos = rig.transform.position;
			float rad = ((Mathf.PI) / 180) * angle;
			float cos = Mathf.Cos(rad);
			pos.z += 0.1F * (Input.GetAxis ("Horizontal") * cos);
			pos.x += 0.1F * (Input.GetAxis ("Horizontal") * Mathf.Cos ((Mathf.PI / 2) - rad));
			rig.transform.position = pos;
			if (Input.GetAxis ("Horizontal") != 0)
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

	public void SwitchFlameThrower ()
	{
		flamethrower = !flamethrower;
	}

	public void FlameThrower ()
	{
		Vector3 FlamesPos = Flames.transform.position;
		if (flamethrower) 
		{
			if (TankerIsNotEmpty ()) 
			{
				FlamesPos.y = 1;
				Flames.transform.position = FlamesPos;
				if (currentTanker)
					tanker1--;
				else
					tanker2--;
			} 
			else
				flamethrower = false;
		}
		else
		{
			FlamesPos.y = -1000;
			Flames.transform.position = FlamesPos;
		}
	}

	void TankersManager ()
	{
		if (currentTanker && tanker2 < 1000)
			tanker2++;
		else if (!currentTanker && tanker1 < 1000)
			tanker1++;
	}

	bool TankerIsNotEmpty ()
	{
		return ((currentTanker && tanker1 > 0) || (!currentTanker && tanker2 > 0));
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Heal")
		{
			health += 150;
			if (health >= 1000)
				health = 1000;
			ammo += 15;
			if (ammo >= 25)
				ammo = 25;
		}

		if (other.tag == "Explosion")
			health -= 10;
	}

	void IsDead()
	{
		if (health <= 0)
			Destroy (rig.gameObject);
	}

	public void SwitchTanker()
	{
		currentTanker = !currentTanker;
	}
}
