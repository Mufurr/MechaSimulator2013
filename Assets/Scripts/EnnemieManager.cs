using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnnemieManager : MonoBehaviour {

    private List<Enemy> ListEnemy = new List<Enemy> { };

    public Enemy test;

    public Rigidbody Player;

	// Use this for initialization
	void Start ()
	{
		ListEnemy.Add(test);
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(Enemy i in ListEnemy){
		    i.Target = Player.transform.position;
        	}
	}
}
