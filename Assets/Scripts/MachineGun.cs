using UnityEngine;
using System.Collections;

public class MachineGun : MonoBehaviour 
{
	public Bullet bullet;
	private Transform Trans;
	private int cooldown;

	void Start () 
	{
		Trans = GetComponent<Transform> ();
		cooldown = 2;
	}
	
	public void Shoot () 
	{
		if (cooldown <= 0)
		{
			Instantiate (bullet, Trans.position, Trans.rotation);
			cooldown = 2;
		}
		else
			cooldown--;
	}
}
