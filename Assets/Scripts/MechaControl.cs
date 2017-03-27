using UnityEngine;
using System.Collections;

public class Mecha : MonoBehaviour 
{

	private Rigidbody rig;
	public int health { get; private set; }
	public bool currentTanker { get; private set; }
	public int tanker1  { get; private set; }
	public int tanker2 { get; private set; }
	private Vector3 pos;
	private float angle;
	public Arm arm;
	public Missile missile;
	public int ammo { get; private set; }
	private int reload;
	private int reloadMissile = 0;
	public Collider Flames;
	private bool flamethrower;

	void Start () 
	{
		rig = GetComponent<Rigidbody> ();
		health = 500;
		ammo = 35;
		tanker1 = 1000;
		tanker2 = 1000;
		reload = 35;
		flamethrower = false;

	}

	void Update () 
	{
		IsDead ();
		TankersManager ();
		if (Input.GetAxisRaw ("Switch joystick") > 0)
		{
			arm.Move ();
		}
		else
		{
			Move ();
		}
		FlameThrower ();
		reloadMissile--;
	}

	void Move ()
	{
		if (TankerIsNotEmpty())
		{
			pos = rig.transform.position;
			float rad = ((Mathf.PI) / 180) * angle;
			float cos = Mathf.Cos(rad);
			pos.z += 0.15F * (Input.GetAxis ("Vertical") * cos);
			pos.x += 0.15F * (Input.GetAxis ("Vertical") * Mathf.Cos ((Mathf.PI / 2) - rad));
			rig.transform.position = pos;
			if (Input.GetAxis ("Vertical") != 0)
			{
				if (currentTanker)
					tanker1--;
				else
					tanker2--;
			}
			angle += 1.5F * Input.GetAxis("Horizontal");
			rig.transform.rotation = Quaternion.Euler(0, angle, 0);
		}
	}

	public void Shoot()
	{
		if (ammo > 0 && reloadMissile <= 0)
		{
			Instantiate (missile, new Vector3 (pos.x, pos.y + 0.25F, pos.z), rig.rotation);
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
		Flames.transform.localRotation = Quaternion.Euler(-90, 0, -90);
		if (flamethrower) 
		{
			if (TankerIsNotEmpty ()) 
			{
				Flames.transform.localPosition = new Vector3(0, -7, 0);
				if (currentTanker)
					tanker1 -= 2;
				else
					tanker2 -= 2;
			} 
			else
				flamethrower = false;
		}
		else
		{
			Flames.transform.localPosition = new Vector3(-50, -7.5F, 0);
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
			//ReloadingPoint here = other.GetComponent<>;
			health += 100;
			if (health >= 500)
				health = 500;
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
