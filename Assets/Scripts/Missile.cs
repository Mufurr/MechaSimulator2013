using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public Transform Trans;

    public float speed;
    public float delta;

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
    }

    float ToRad(float angle)
    {
        return ((Mathf.PI) / 180) * angle;
    }
}
