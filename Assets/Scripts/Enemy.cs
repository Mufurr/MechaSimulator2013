using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Rigidbody rig;

	public Vector3 Target { private get; set; }

	public float speed;

	public NavMeshAgent agent;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		Target = rig.transform.position;
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		agent.SetDestination(Target);
	}
}
