using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScreenMechState : Screen {

    public Text texter;

	// Use this for initialization
	new void Start () {
        base.Start();
        type = ScreenType.MechState;
	}
	
	// Update is called once per frame
	void Update () {
        texter.text = text;
	}
}
