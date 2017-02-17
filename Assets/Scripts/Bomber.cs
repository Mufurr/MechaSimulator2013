using UnityEngine;
using System.Collections;
using System;

public class Bomber : Enemy {

    public bool MechInRange = false;
    
    public override void Start()
    {
        level = 1;
    }

    protected override void Fire()
    {
        if (MechInRange) {
            Destroy(rig.gameObject);
            Debug.Log("A bomber exploded !");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MechInRange = true;
            Debug.Log("A Mech is in range !");
        }
    }
}
