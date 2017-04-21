using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public int health { get; private set; }

	void Start () 
	{
		health = 100;
	}
	
	public void Reload ()
	{
		health += 15;
		if (health >= 100)
			health = 100;
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.tag == "Projectile" || other.tag == "Explosion")
			health -= 10;
	}
}
