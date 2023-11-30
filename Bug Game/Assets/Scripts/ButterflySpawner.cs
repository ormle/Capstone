using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflySpawner : MonoBehaviour
{
    public GameObject[] butterflyPrefabs;
    public float startDelay = 0f;
    public float spawnInterval = 45f;

    public Transform[] routes;
    private List<Transform> Paths;

    // Start is called before the first frame update
    void Start()
    {
        new WaitForSeconds(startDelay);
        StartCoroutine("SpawnRandomButterfly", spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRandomButterfly(float spawnInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            //Randomly pick a butterfly
            int bIndex = Random.Range(0, butterflyPrefabs.Length);

            //Put paths in array to give to mvmt script
            Paths = new List<Transform>();
            for (int i = 0; i < routes[0].childCount; i++) {
                Paths.Add(routes[0].GetChild(i));
            }

            //Spawn pos of first path
            Vector2 spawnPos = Paths[0].GetChild(0).localPosition;
            //Spawn bug with calculated rotation angle
            GameObject bug = Instantiate(butterflyPrefabs[bIndex], spawnPos,
                Quaternion.Euler(0f, 0f, 0));
            bug.transform.SetParent(transform, false);

            //Access MoveCurve Script
            MoveCurve moveScript = bug.GetComponent<MoveCurve>();
            if (moveScript != null) {
                moveScript.Speed += 0.8f; //Add to speed
                moveScript.Paths = Paths;    //Give the script the route
                moveScript.bugPos = spawnPos;//Give script bug position
            }
        }
    }
}
