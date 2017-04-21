using UnityEngine;
using System.Collections;

public class ziguiguidansleciel : MonoBehaviour {

    public Rigidbody rig = new Rigidbody();
    private int health;
    private Vector3 pos;

    void Start()
    {
        pos = rig.transform.position;
        health = 300;
    }

    void FixedUpdate()
    {
        if (IsDead())
            Fall();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Explosion")
            health -= 10;
    }

    bool IsDead()
    {
        return health <= 0;
    }

    void Fall()
    {
        pos = rig.transform.position;
        if (pos.y >= 1000)
        {
            pos.y += 0.2F;
        }
        rig.transform.position = pos;
    }
}