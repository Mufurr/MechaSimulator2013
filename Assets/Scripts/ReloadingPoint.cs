using UnityEngine;
using System.Collections;

public class ReloadingPoint : MonoBehaviour {

	public Collider Coll;
	public MechaControl Mecha;
	private int heal;
	private int cooldown;

	void Start () 
	{
		heal = 50;
		cooldown = 120;
	}
	
	void Update () 
	{
		cooldown--;	
	}
}
