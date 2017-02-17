using UnityEngine;
using System.Collections;

public class Blaster : Enemy {

    private int reload;
    public int reloadRate;

    public GameObject Missile;

    public override void Start()
    {
        level = 1;
    }

    protected override void Fire()
    {
        RaycastHit Hit;
        if (reload == 0)
        {
            if (Physics.Raycast(rig.position, rig.transform.TransformDirection(Vector3.forward), out Hit)
                && Hit.collider.tag == "Player")
            {
                Instantiate(Missile, rig.position, rig.rotation);
                reload = reloadRate;
            }
        }
        else {
            reload--;
        }
    }
}