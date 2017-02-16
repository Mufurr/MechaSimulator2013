using UnityEngine;
using System.Collections;

public class MechaControl : MonoBehaviour
{

    public Rigidbody rig = new Rigidbody();
    private Vector3 pos;
    public float speed;
    public float rotation;
    public float angle;

    void Start()
    { }

    void Update()
    {
        Move();
        Rotation();
    }

    void Move()
    {
        pos = rig.transform.position;
        float rad = ToRad(angle);
        pos.z += speed * (Input.GetAxis("Horizontal2") * Mathf.Cos(rad) + Input.GetAxis("Horizontal") * Mathf.Cos((Mathf.PI / 2) + rad));
        pos.x += speed * (Input.GetAxis("Horizontal2") * Mathf.Cos((Mathf.PI / 2) - rad) + Input.GetAxis("Horizontal") * Mathf.Cos(rad));
        rig.transform.position = pos;
    }

    void Rotation()
    {
        angle += rotation * Input.GetAxis("Rotation");
        rig.transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    float ToRad(float angle)
    {
        return ((Mathf.PI) / 180) * angle;
    }
}