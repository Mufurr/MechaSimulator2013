﻿using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    public Rigidbody rig;

    public Vector3 Target { protected get; set; }
    public float distance;
    public bool TargetPlayer;

    public float speed;
    public float safeDistance;

    public static int level { protected set; get; }

    private int Life = 20;
    public bool alive = true; 

    public NavMeshAgent agent;

    // Use this for initialization
    public virtual void Start () {
        //agent = GetComponent<NavMeshAgent>();
        Target = rig.transform.position;
        alive = true;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (TargetPlayer)
        {
            MoveToPlayer();
        }
        else
        {
            agent.SetDestination(Target);
        }
        if(Life <= 0)
        {
            alive = false;
            Destroy(this.gameObject);
        }
    }

    void MoveToPlayer()
    {
        RaycastHit Hit;
        if (Mathf.Abs(Target.x - rig.transform.position.x) + Mathf.Abs(Target.z - rig.transform.position.z) < safeDistance)
        {
            rig.rotation = Quaternion.LookRotation(Target - rig.position);
            rig.velocity = rig.transform.TransformDirection(Vector3.back);
            agent.ResetPath();
        }
        else if (Mathf.Abs(Target.x - rig.transform.position.x) + Mathf.Abs(Target.z - rig.transform.position.z) > distance
             || !(Physics.Raycast(rig.position, rig.transform.TransformDirection(Vector3.forward), out Hit) && Hit.transform.position.x == Target.x
             && Hit.transform.position.y == Target.y))
        {
            agent.SetDestination(Target);
        }
        else
        {
            rig.rotation = Quaternion.LookRotation(Target - rig.position);
            rig.velocity = Vector3.zero;
            agent.ResetPath();
        }
        Fire();
    }

    protected void OnTriggerEnter(Collider other) {
        if(other.tag == "Explosion")
        {
            Life -= 10;
        }
    }

    protected abstract void Fire();
}
