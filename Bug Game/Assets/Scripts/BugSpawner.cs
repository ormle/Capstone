using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{ 
    //List of bug prefabs to go through and spawn randomly
    public GameObject[] beetlePrefabs, ladybugPrefabs, beePrefabs,
        dragonflyPrefabs, butterflyPrefabs;
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
    - Offscreen up/down Y position = 1070 (+ up, - down) 
    - Offscreen left/right x range position = 1450 (- left, + right)
     */
    private float spawnPos_UD_Y = 1070;   //Not a range, either + or -
    private float spawnRange_UD_X = 1450; //X ranges where they can spawn


    // Start is called before the first frame update
    void Start()
    {
        //Beetle
        InvokeRepeating("SpawnRandomBeetle", startDelay, spawnInterval);
        //Ladybug
        InvokeRepeating("SpawnRandomLadybug", startDelay, spawnInterval);
        //Bee
        InvokeRepeating("SpawnRandomBee", startDelay, spawnInterval);
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomBug_original()
    {
        //Randomly generate bug index
        //Pick a random bug to spawn
        int bugIndex = Random.Range(0, beetlePrefabs.Length);
        //Randomly generate spawn location
        Vector3 spawnPos = new Vector3(-spawnPos_RL_X,
            Random.Range(-spawnRange_RL_YL, spawnRange_RL_YU), 0);
        //Spawn bug
        GameObject bug = Instantiate(beetlePrefabs[bugIndex], spawnPos,
            beetlePrefabs[bugIndex].transform.rotation);
        bug.transform.SetParent(transform, false);
        Debug.Log(spawnPos);
        
    }

    void SpawnRandomBeetle()
    {
        // Randomly generate bug index
        int bugIndex = Random.Range(0, beetlePrefabs.Length);
        
        // Randomly generate spawn location
        Vector3 spawnPos = new Vector3(-spawnPos_RL_X, 
            Random.Range(-spawnRange_RL_YL, spawnRange_RL_YU), 0);
    
        // Spawn bug
        GameObject bug = Instantiate(beetlePrefabs[bugIndex], spawnPos, 
            beetlePrefabs[bugIndex].transform.rotation);
        bug.transform.SetParent(transform, false);
    
        // Access the MoveForward script on the spawned bug and change its speed
        MoveForward moveScript = bug.GetComponent<MoveForward>();
        if (moveScript != null)
        {
            
            moveScript.speed = 0.9f; // Set to the desired speed value?
        }
    
        Debug.Log(spawnPos);
        
        // Start a coroutine to control bug movement
        StartCoroutine(LadybugMovement(bug, moveScript));

    }
    
    // USES Ladybug Coroutine!
    void SpawnRandomLadybug()
    {
        float spawnPos_RL_X = -2020; // Change this value to make bugs spawn on the right
        
        // Randomly generate bug index
        int bugIndex = Random.Range(0, beetlePrefabs.Length);
        
        // Randomly generate spawn location
        Vector3 spawnPos = new Vector3(-spawnPos_RL_X, Random.Range(-spawnRange_RL_YL, spawnRange_RL_YU), 0);
        
        // Calculate a random rotation angle between 88 and 92 degrees.
        float randomRotation = Random.Range(88f, 92f);
        
        // Spawn bug with the calculated random rotation angle.
        GameObject bug = Instantiate(beetlePrefabs[bugIndex], spawnPos, Quaternion.Euler(0f, 0f, randomRotation));
        bug.transform.SetParent(transform, false);
        
        // Access the MoveForward script on the spawned bug and change its speed
        MoveForward moveScript = bug.GetComponent<MoveForward>();
        if (moveScript != null)
        {
            // Calculate a random speed variation between -0.3 and 0.3, adding it to the base speed of 0.9.
            float speedVariation = Random.Range(-0.3f, 0.3f);
            moveScript.speed = 0.9f + speedVariation;
        }
        
        Debug.Log(spawnPos);
    
        // Start a coroutine to control bug movement
        StartCoroutine(LadybugMovement(bug, moveScript));
    }

    // This is a special coroutine for the bug
    // Think of it like its dance choreography
    IEnumerator LadybugMovement(GameObject bug, MoveForward moveScript)
    {
        // Move for a random duration between 2 and 9 seconds
        float moveDuration = Random.Range(1f, 9f);
        yield return new WaitForSeconds(moveDuration);

        // Stop moving for a random duration between 3 and 9 seconds
        float stopDuration = Random.Range(0.2f, 3f);
        moveScript.speed = 0f;
        yield return new WaitForSeconds(stopDuration);

        //if statement is fix for accessing deleted object error - yron

        if (bug)
        { 
        // Rotate to a random angle between 0 and 270 degrees
        float randomRotation = Random.Range(0f, 270f);
        bug.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
        }

        // Resume moving with a random speed between 0.9 and 1.6
        float randomSpeed = Random.Range(0.9f, 1.6f);
        moveScript.speed = randomSpeed;
    
        // You can repeat this cycle as needed
        StartCoroutine(LadybugMovement(bug, moveScript));
    }

    
        IEnumerator AlternateMovement2(GameObject bug, MoveForward moveScript)
    {
        // Move for 3 seconds
        yield return new WaitForSeconds(3f);
    
        // Stop moving for 3 seconds
        moveScript.speed = 0f;
        yield return new WaitForSeconds(3f);
    
        // Resume moving (you can adjust the speed here)
        moveScript.speed = 0.9f;
    
        // You can repeat this cycle as needed
        StartCoroutine(AlternateMovement2(bug, moveScript));
    }

    void SpawnRandomBee()
    {
        //0 = Spawn from top, 1 spawn from bottom
        int randUpDown = Random.Range(0, 1);
        float upDown = spawnPos_UD_Y;
        if (randUpDown == 1)
        {
            upDown = spawnPos_UD_Y * -1;
        }

        // Randomly generate bug index
        int bugIndex = Random.Range(0, beePrefabs.Length);

        // Randomly generate spawn location
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange_UD_X, spawnRange_UD_X),
            upDown, 0);

        // Calculate a random rotation angle between 88 and 92 degrees.
        float randomRotation = Random.Range(88f, 92f);

        // Spawn bug with the calculated random rotation angle.
        GameObject bug = Instantiate(beePrefabs[bugIndex], spawnPos, Quaternion.Euler(0f, 0f, randomRotation));
        bug.transform.SetParent(transform, false);

        // Access the MoveForward script on the spawned bug and change its speed
        MoveForward moveScript = bug.GetComponent<MoveForward>();
        if (moveScript != null)
        {
            // Calculate a random speed variation between -0.3 and 0.3, adding it to the base speed of 0.9.
            float speedVariation = Random.Range(-0.3f, 0.3f);
            moveScript.speed = 0.9f + speedVariation;
        }

        Debug.Log(spawnPos);

        // Start a coroutine to control bug movement
        StartCoroutine(BeeMovement(bug, moveScript));
    }

    IEnumerator BeeMovement(GameObject bug, MoveForward moveScript)
    {//Right now is a copy of LadyBugMovement as a skeleton/guide
        // Move for a random duration between 2 and 9 seconds
        float moveDuration = Random.Range(1f, 9f);
        yield return new WaitForSeconds(moveDuration);

        // Stop moving for a random duration between 3 and 9 seconds
        float stopDuration = Random.Range(0.2f, 3f);
        moveScript.speed = 0f;
        yield return new WaitForSeconds(stopDuration);

        //if statement is fix for accessing deleted object error - yron

        if (bug)
        {
            // Rotate to a random angle between 0 and 270 degrees
            float randomRotation = Random.Range(0f, 270f);
            bug.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
        }

        // Resume moving with a random speed between 0.9 and 1.6
        float randomSpeed = Random.Range(0.9f, 1.6f);
        moveScript.speed = randomSpeed;

        // You can repeat this cycle as needed
        StartCoroutine(BeeMovement(bug, moveScript));
    }
    

}
