using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCurve : MonoBehaviour
{
    public List<Transform> Paths; //Given from BugSpawner
    public BugSpawner spawnScript;

    private int PathToGo = 0;
    private float tParam = 0f;
    public Vector2 bugPos;   
    public float Speed = 0.15f;

    private bool coroutineAllowed = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed) { StartCoroutine(GoRoute(PathToGo)); }
    }

    private IEnumerator GoRoute(int PathNo)
    {
        coroutineAllowed = false;//So no new coroutines will start

        //Control point positions
        Vector2 p0 = Paths[PathNo].GetChild(0).position;//Start point
        Vector2 p1 = Paths[PathNo].GetChild(1).position;
        Vector2 p2 = Paths[PathNo].GetChild(2).position;
        Vector2 p3 = Paths[PathNo].GetChild(3).position;//End point

        while (tParam < 1)
        {//Calculate and set bug position
            tParam += Time.deltaTime * Speed;
            //Formula of bezier curve
            bugPos = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            //Need to figureout how to make bug rotate to look forward
            //At this point
            //This was a suggestion in youtube comments, but only works for 3D
            //transform.LookAt(bugPos);
            Vector3 direction = new Vector3(bugPos.x - transform.position.x,
                bugPos.y - transform.position.y, 0f);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            transform.position = bugPos;//Move bug position
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        PathToGo += 1;//Go along next curve if exist

        if (PathToGo > Paths.Count - 1)
        { //Destroy bug if route end
            Destroy(gameObject);
        }

        coroutineAllowed = true;//Able to start next
    }
}
