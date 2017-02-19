using UnityEngine;
using System.Collections;

public enum MechFunction { Shoot, None}

public class ButtonManager : MonoBehaviour {

    private Button[] buttonList;
    public new Camera camera;

    public MechaControl Mech;

	// Use this for initialization
	void Start () {
        buttonList = GameObject.FindObjectsOfType<Button>();
        if(buttonList.Length > 0)
        {
            buttonList[0].function = MechFunction.Shoot;
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
                        //Mech.Shoot();
                        break;
                }
            }
        }
    }
}