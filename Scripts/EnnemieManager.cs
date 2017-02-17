using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

enum EnemyType { Blaster, Bomber};

public class EnnemieManager : MonoBehaviour {

    private List<Enemy> ListEnemy = new List<Enemy> { };
    private List<Spawner> ListSpawner = new List<Spawner> { };

    public Rigidbody Player;
    private int Level = 6;

    public Enemy PrefabBlaster;
    public Enemy PrefabBomber;

    void Start()
    {
        Enemy[] ArrayEnemy = FindObjectsOfType<Enemy>();
        foreach (Enemy i in ArrayEnemy)
        {
            ListEnemy.Add(i);
        }
        Spawner[] ArraySpawner = FindObjectsOfType<Spawner>();
        foreach (Spawner i in ArraySpawner)
        {
            ListSpawner.Add(i);
        }
    }
	
	void FixedUpdate () {
        System.Random rand = new System.Random();
        foreach(Enemy i in ListEnemy)
        {
            i.Target = Player.transform.position;
            i.TargetPlayer = true;
        }
        int LackScore = Level - GetScore();
        Debug.Log(LackScore);
        switch (rand.Next(2)) {
            case 0:
                if(LackScore >= Blaster.level) {
                    ListSpawner[rand.Next(ListSpawner.Count)].Spawn(PrefabBlaster, ListEnemy);
                }
                break;
            case 1:
                if (LackScore >= Bomber.level)
                {
                    ListSpawner[rand.Next(ListSpawner.Count)].Spawn(PrefabBomber, ListEnemy);
                }
                break;
        }
	}

    int GetScore()
    {
        int res = 0;
        foreach (Enemy i in ListEnemy) {
            switch (i.GetType().ToString()) {
                case "Blaster":
                    res += Blaster.level;
                    break;
                case "Bomber":
                    res += Bomber.level;
                    break;
            }
        }
        return res;
    }
}
