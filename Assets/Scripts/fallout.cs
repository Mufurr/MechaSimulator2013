using UnityEngine;
using System.Collections;

public class fallout : MonoBehaviour
{

    public Rigidbody rig = new Rigidbody();
    private int health;
    private Vector3 pos;

    void Start()
    {
        health = 300;
    }

    void fixUpdate()
    {
        if ((health <= 0) && (transform.position.y > -0.5f))
        {
            float g = (transform.position.y - 0.01f);
            SetTransformX(g);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Explosion")
            health -= 10;
    }
    void SetTransformX(float n)
    {
        transform.position = new Vector3(transform.position.x, n , transform.position.z);
    }
}