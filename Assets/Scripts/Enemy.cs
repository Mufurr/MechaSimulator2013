using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Rigidbody rig;

    public Vector3 Target { private get; set; }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(rig.transform.position.x - Target.x + rig.transform.position.y - Target.y) > 10) { }
	}

    private void Move() { }
}
