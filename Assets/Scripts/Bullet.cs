using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Transform Trans;
	private int lifetime;
	private float speed;

	void Start () 
	{
		Trans = GetComponent<Transform> ();
		lifetime = 30;
		speed = 0.25F;
	}
	
	void Update () 
	{
		System.Random rand = new System.Random ();
		float angley = Trans.rotation.eulerAngles.y - 45;
		float anglex = Trans.rotation.eulerAngles.x;
		Vector3 pos = Trans.position;
		float rady = ToRad (angley);
		float radx = ToRad (anglex);
		float aleaSpeed = ((float)(rand.Next (3) + 9)) / 10f;
		pos.z += speed * aleaSpeed * (Mathf.Cos(rady) + Mathf.Cos((Mathf.PI / 2) + rady));
		pos.x += speed * aleaSpeed * (Mathf.Cos((Mathf.PI / 2) - rady) + Mathf.Cos(rady));
		pos.y -= speed * aleaSpeed * Mathf.Sin (radx);
		Trans.position = pos;
		if (lifetime == 0)
			Destroy(Trans.gameObject);
		else
			lifetime--;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Map" || other.tag == "Enemy")
			Destroy (Trans.gameObject);
	}

	float ToRad(float angle)
	{
		return ((Mathf.PI) / 180) * angle;
	}
}
