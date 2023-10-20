using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{ 
    //List of bug prefabs to go through and spawn randomly
    public GameObject[] bugPrefabs;
    public float startDelay = 3f;    //So bugs spawn after countdown
    public float spawnInterval = 2.5f; //Spawn every 2.5 seconds

    /*
    SpawnrangeY determines the Y range they can spawn in
    (The up and down range they can spawn from, use +- of this float)
    SpawnPosX is the x position they will spawn at (Left right)
    We want them to spawn offscreen then crawl onto screen so
    ======================
    =Left <--> Right Bugs=
    ======================
    - Offscreen left/right X position = -1777 (- left, + right) 
    - Offscreen up Y position = 200
    - Offscreen down Y position = -700
    */
    private float spawnRange_RL_YL = 900;   //Y lower limit where they can spawn
    private float spawnRange_RL_YU = 200;   //Y upper limit where they can spawn
    private float spawnPos_RL_X = 2020;     //X position where they spawn, Not a range
    
    /*
    ===================
    =Up <--> Down Bugs=
    ===================
    - Offscreen up/down Y position = 1100 (+ up, - down) 
    - Offscreen left/right x range position = 1450 (- left, + right)
     */
    //private float spawnPos_UD_Y = 1070;   //Not a range, either + or -
    //private float spawnRange_UD_X = 1450; //X ranges where they can spawn


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBug", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomBug_original()
    {
        //Randomly generate bug index
        //Pick a random bug to spawn
        int bugIndex = Random.Range(0, bugPrefabs.Length);
        //Randomly generate spawn location
        Vector3 spawnPos = new Vector3(-spawnPos_RL_X,
            Random.Range(-spawnRange_RL_YL, spawnRange_RL_YU), 0);
        //Spawn bug
        GameObject bug = Instantiate(bugPrefabs[bugIndex], spawnPos,
            bugPrefabs[bugIndex].transform.rotation);
        bug.transform.SetParent(transform, false);
        Debug.Log(spawnPos);
        
    }

    void SpawnRandomBug()
    {
        // Randomly generate bug index
        int bugIndex = Random.Range(0, bugPrefabs.Length);
        
        // Randomly generate spawn location
        Vector3 spawnPos = new Vector3(-spawnPos_RL_X, 
            Random.Range(-spawnRange_RL_YL, spawnRange_RL_YU), 0);
    
        // Spawn bug
        GameObject bug = Instantiate(bugPrefabs[bugIndex], spawnPos, 
            bugPrefabs[bugIndex].transform.rotation);
        bug.transform.SetParent(transform, false);
    
        // Access the MoveForward script on the spawned bug and change its speed
        MoveForward moveScript = bug.GetComponent<MoveForward>();
        if (moveScript != null)
        {
            
            moveScript.speed = 0.9f; // Set to the desired speed value?
        }
    
        // Debug.Log(spawnPos);

    }
    

}
