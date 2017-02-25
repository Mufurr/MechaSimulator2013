using UnityEngine;
using System.Collections;
using System;

public class Bomber : Enemy {

    public bool MechInRange = false;

    public Explosion expl;
    
    public override void Start()
    {
        level = 1;
    }

    protected override void Fire()
    {
        if (MechInRange)
        {
            Instantiate(expl, rig.position, rig.rotation);
            Destroy(rig.gameObject);
            alive = false;
        }
    }

    new void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.tag == "Player")
        {
            MechInRange = true;
        }
    }
}
