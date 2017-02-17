using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public Transform Trans;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn(Enemy enemy, List<Enemy> ListEnemy)
    {
        Debug.Log("An enemy tries to spawn");
        Vector3 Pos = new Vector3(Trans.position.x, Trans.position.y + 2, Trans.position.z);
        Enemy instant = Instantiate(enemy);
        ListEnemy.Add(instant);
        instant.transform.position = Pos;
    }
}
