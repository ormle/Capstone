using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugSpawner : MonoBehaviour
{
    public GameObject bug;
    public Vector3 spawnValues;
    public float spawnWait = 2;
    public float spawnMostWait = 5;
    public float spawnLeastWait = 1;
    public int startWait;
    public bool stop;

    int randBug;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner() {
        yield return new WaitForSeconds(startWait);
        while (!stop) {
            randBug = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y - 300), -15);

            Instantiate(bug, spawnPosition, gameObject.transform.rotation, GameObject.FindGameObjectWithTag("Bug").transform);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
