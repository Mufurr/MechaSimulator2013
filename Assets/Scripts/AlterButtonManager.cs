using UnityEngine;
using System.Collections.Generic;

public class AlterButtonManager : MonoBehaviour {

	private Button[] buttonList;
	public new Camera camera;

	public AlterMecha Mech;

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
					Debug.Log ("None");
					return;
				case MechFunction.MissileShoot:
					Mech.Shoot();
					return;
				case MechFunction.SwitchTanker:
					Mech.SwitchTanker ();
					Debug.Log ("Tankers switched");
					return;
				case MechFunction.SwitchFlameThrower:
					Mech.SwitchFlameThrower ();
					return;
				case MechFunction.ReloadShield:
					Mech.ReloadShield ();
					Debug.Log ("Shield reloaded");
					return;
				case MechFunction.SwitchMachineGun:
					Mech.SwitchMachineGun ();
					return;
				case MechFunction.SwitchSword:
					Mech.SwitchSword ();
					return;
				}
			}
		}
	}
}