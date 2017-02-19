using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public MechFunction function;//{ private set; get; } 

    public bool selected { private set; get; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetFunction(MechFunction x)
    {
        function = x;
    }
}
