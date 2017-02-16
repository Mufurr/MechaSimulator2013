using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public Transform Trans;

    public float speed;
    public float delta;
    public int LifeTime;
    public bool Enemy;

	void Start () {
	}


	void FixedUpdate ()
    {
        float angle = Trans.rotation.eulerAngles.y - 45;//For some weird reasons, the missile won't go in the right directin without this "- 45"
        Vector3 pos = Trans.position;
        float rad = ToRad(angle);
        pos.z += speed * (Mathf.Cos(rad) + Mathf.Cos((Mathf.PI / 2) + rad));
        pos.x += speed * (Mathf.Cos((Mathf.PI / 2) - rad) + Mathf.Cos(rad));
        Trans.position = pos;
        if (LifeTime == 0)
        {
            Destroy(Trans.gameObject);
        }else {
            LifeTime--;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Enemy && other.tag == "Player") {
            Destroy(Trans.gameObject);
        }
        if (!Enemy && other.tag == "Enemy") {
            Destroy(Trans.gameObject);
        }
        if (other.tag == "Obstacle") {
            Destroy(Trans.gameObject);
        }
    }

    float ToRad(float angle)
    {
        return ((Mathf.PI) / 180) * angle;
    }
}
