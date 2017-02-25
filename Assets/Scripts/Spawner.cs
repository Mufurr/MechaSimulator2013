using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public Transform Trans;

    private int reload = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        reload--;
	}

    public bool Spawn(Enemy enemy, List<Enemy> ListEnemy)
    {
        if(reload > 0)
        {
            return false;
        }
        Debug.Log("An enemy tries to spawn");
        Vector3 Pos = new Vector3(Trans.position.x, Trans.position.y + 2, Trans.position.z);
        Enemy instant = Instantiate(enemy);
        ListEnemy.Add(instant);
        instant.transform.position = Pos;
        reload = 40;
        return true;
    }
}
