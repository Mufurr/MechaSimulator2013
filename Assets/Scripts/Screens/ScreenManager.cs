using UnityEngine;
using System.Collections;

public enum ScreenType { MainView, MechState, MechAmmo, GameOver}

public class ScreenManager : MonoBehaviour {

    Screen[] screens;
    MechaControl Mech;

    public Camera GameOver;


	// Use this for initialization
	void Start () {
        screens = FindObjectsOfType<Screen>();
        Mech = FindObjectOfType<MechaControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Mech.health <= 0)
        {
            foreach(Screen i in screens)
            {
                i.type = ScreenType.GameOver;
                i.SetTexture(GameOver);
            }
        }
        foreach(Screen i in screens)
        {
            switch(i.type)
            {
                case ScreenType.MechState:
                    i.text = "o Energy tank :\n";
                    for(int j = 0; j < ((Mech.currentTanker) ? Mech.tanker1 : Mech.tanker2); j+= 100)
                    {
                        i.text += "[]";
                    }
                    i.text += "\no Reserve tank :\n";
                    for (int j = 0; j < ((Mech.currentTanker) ? Mech.tanker2 : Mech.tanker1); j +=100)
                    {
                        i.text += "[]";
                    }
                    i.text += "\no State of the Jaeger:\n";
                    for (int j = 0; j <= Mech.health; j += 100)
                    {
                        i.text += "[]";
                    }
                    break;
                case ScreenType.MechAmmo:
                    i.text = "o Missile Launcher :\n";
                    for (int j = 0; j < Mech.ammo; j ++)
                    {
                        i.text += "|";
                    }
                    i.text += "\no Flame Thrower :\n";
                    for (int j = 0; j < 10; j ++)
                    {
                        i.text += "=";
                    }
                    break;
            }
        }
	}
}
