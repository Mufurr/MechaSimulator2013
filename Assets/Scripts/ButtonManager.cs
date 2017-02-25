﻿using UnityEngine;
using System.Collections.Generic;

public enum MechFunction { Shoot, SwitchTanker, None}

public class ButtonManager : MonoBehaviour {

    private Button[] buttonList;
    public new Camera camera;

    public MechaControl Mech;

	// Use this for initialization
	void Start () {
        buttonList = GameObject.FindObjectsOfType<Button>();
        List<MechFunction> ListFunctions = new List<MechFunction> { MechFunction.Shoot, MechFunction.SwitchTanker };
        foreach(Button i in buttonList)
        {
            if(ListFunctions.Count > 0)
            {
                System.Random rand = new System.Random();
                int index = rand.Next(ListFunctions.Count);
                i.function = ListFunctions[index];
                ListFunctions.Remove(ListFunctions[index]);
            } else
            {
                i.function = MechFunction.None;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit Hit;
            MechFunction clickedFunction = MechFunction.None;
            if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out Hit))
            {
                foreach (Button i in buttonList)
                {
                    if (Hit.collider.gameObject.transform.position == i.transform.position)
                    {
                        clickedFunction = i.function;
                        break;
                    }
                }
                switch (clickedFunction)
                {
                    case MechFunction.None:
                        return;
                    case MechFunction.Shoot:
                        Mech.Shoot();
                        return;
                    case MechFunction.SwitchTanker:
                        Mech.Switch_Tanker();
                        return;
                }
            }
        }
    }
}