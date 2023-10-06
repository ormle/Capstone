using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugSpawner : MonoBehaviour
{
    //List of bug prefabs to go through and spawn randomly
    public GameObject[] bugPrefab;     
    //public Vector3 spawnValues;
    public float startDelay = 3;       //So bugs don't spawn immediately
    public float spawnInterval = 2.5f; //Spawn every 1.5 seconds
    /*
     SpawnrangeY determines the Y range they can spawn in
     (The up and down range they can spawn from, use +- of this float)

     SpawnPosX is the x position they will spawn at (Left right)
     We want them to spawn offscreen then crawl onto screen so
     Offscreen left x position = -1777 (Crawl left to right)
     Offscreen right x position = 1777 (Crawl right to left)
     */
    public float spawnRangeYL = 700.0f;   //Y lower limit where they can spawn
    public float spawnRangeYU = 200.0f;   //T upper limit where they can spawn
    public float spawnPosX = 1777.0f;     //X position where they spawn


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBug", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void SpawnRandomBug()
    {
        //Randomly generate bug index
        int bugIndex = Random.Range(0, bugPrefab.Length);
        //Randomly generate spawn location
        Vector3 spawnPos = new Vector3(-spawnPosX,
            Random.Range(-spawnRangeYL, spawnRangeYU), 0);
        //Spawn bug
        Instantiate(bugPrefab[bugIndex], spawnPos,
            bugPrefab[bugIndex].transform.rotation);
    }
    
}
