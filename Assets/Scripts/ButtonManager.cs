using UnityEngine;
using System.Collections.Generic;

public enum MechFunction { MissileShoot, SwitchTanker, SwitchFlameThrower, ReloadShield, SwitchMachineGun, SwitchSword, None}

public class ButtonManager : MonoBehaviour {

	private Button[] buttonList;
	public new Camera camera;

	public Mecha Mech;

	void Start () 
	{
		buttonList = GameObject.FindObjectsOfType<Button>();
		List<MechFunction> ListFunctions = new List<MechFunction> { MechFunction.MissileShoot, MechFunction.SwitchTanker, MechFunction.SwitchFlameThrower, MechFunction.ReloadShield, MechFunction.SwitchMachineGun, MechFunction.SwitchSword };
		foreach(Button i in buttonList)
		{
			if (ListFunctions.Count > 0)
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

	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit Hit;
			MechFunction clickedFunction = MechFunction.None;
			if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(0, -0.34F, 1), out Hit))
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
				case MechFunction.MissileShoot:
					Mech.MissileShoot();
					return;
				case MechFunction.SwitchTanker:
					Mech.SwitchTanker ();
					return;
				case MechFunction.SwitchFlameThrower:
					Mech.SwitchFlameThrower ();
					return;
				case MechFunction.ReloadShield:
					Mech.ReloadShield ();
					return;
				case MechFunction.SwitchMachineGun:
					Debug.Log ("Not yet, amigo");
					return;
				case MechFunction.SwitchSword:
					Debug.Log ("Not yet, amigo");
					return;
				}
			}
		}
	}
}
