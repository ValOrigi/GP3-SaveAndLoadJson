using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    private SaveAndLoading svl;
    private int i;

    // Update is called once per frame
    void Start()
    {
        svl = GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveAndLoading>();

        for (i = 0; i < 10; i++)
        {
            spawn();
            svl.allEenemies.Add(GameObject.Find(""+i));
            svl.initialSpawn.Add(GameObject.Find(""+i).transform.position);
        }
    }

    void spawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-12, 6), 1, Random.Range(-2, 8));
        var en = Instantiate(enemy, randomSpawnPosition, transform.rotation);
        en.name = "" + i;
    }
}
