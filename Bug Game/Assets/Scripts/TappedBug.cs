using UnityEngine;
using TouchScript.Gestures;
using System;
using System.Collections;


public class TappedBug : MonoBehaviour
{
    private AudioSource boinkAudioSource; // Reference to the 'boink' AudioSource
    public bool destroyGameObject = true; // MAKE
    public GameObject pointPrefab;

    private BugSpawner bugSpawner; // Reference BugSpawner for spawn script

    public IEnumerator Dmove; // Dragonfly mvmt coroutine

    void Start()
    {
        TapGesture tapGesture = this.GetComponent<TapGesture>();

        tapGesture.Tapped += TapGesture_Tapped;

        // Find the 'boink' AudioSource by name in the scene
        boinkAudioSource = GameObject.Find("boink").GetComponent<AudioSource>();
        // Find BugSpawner by name in scene
        bugSpawner = GameObject.Find("BugSpawner").GetComponent<BugSpawner>();
    }

    void TapGesture_Tapped(object sender, EventArgs e)
    {
		ScoreManager scoreManager = ScoreManager.instance;
        
        if (Time.timeScale == 1)//Only be able to tap bugs during game time
        {
            if (scoreManager != null)
            {
                //Debug.Log(this.instance);
                if (this.name == "TigerBeetle" ||  this.name == "TigerBeetle(Clone)")
                {
                    this.GetComponent<MoveForward>().speed = 0f; // stops bug movement
                    scoreManager.AddScore(1);
		    scoreManager.BugCounter(2);
                    //fadeOut Coroutine
                    StartCoroutine(FadeOut(1f));
                    //showPoint Coroutine
                    StartCoroutine(ShowPoint(transform.position));
                    //Debug.Log("anim should happe");
                    //Destroy(this.gameObject);

                }
                if (this.name == "ButterflyTemp" || this.name == "ButterflyTemp(Clone)")
				{
                    this.GetComponent<MoveCurve>().Speed = 0f;
                    scoreManager.AddScore(5);
		    scoreManager.BugCounter(4);
                    //fadeOut Coroutine
                    StartCoroutine(FadeOut(1f));
                    //showPoint Coroutine
                    StartCoroutine(ShowPoint(transform.position));
                    //Destroy(gameObject);
                }
                if (this.name == "DragonflyTest" || this.name == "DragonflyTest(Clone)" 
                || this.name == "CherryMeadow" || this.name == "CherryMeadow(Clone)"
                || this.name == "BlueDarner" || this.name == "BlueDarner(Clone)")
				{
                    this.GetComponent<MoveZigZag>().speed = 0f;
                    // Completely stop dragonfly mvmt coroutine
                    // so if tap when rotating does not continue rotating
                    bugSpawner.StopCoroutine(Dmove);
                    scoreManager.AddScore(8);
		    scoreManager.BugCounter(5);
                    //fadeOut Coroutine
                    StartCoroutine(FadeOut(1f));
                    //showPoint Coroutine
                    StartCoroutine(ShowPoint(transform.position));
                    //Destroy(gameObject);
                }
                if (this.name == "BeeTemp" || this.name == "BeeTemp(Clone)")
				{
                    this.GetComponent<MoveCurve>().Speed = 0f;
                    scoreManager.AddScore(10);
		    scoreManager.BugCounter(3);
                    //fadeOut Coroutine
                    StartCoroutine(FadeOut(1f));
                    //showPoint Coroutine
                    StartCoroutine(ShowPoint(transform.position));
                    //Destroy(gameObject);
                }
                ShowScore showScore = FindObjectOfType<ShowScore>();
                if (showScore != null)
                {
                    showScore.UpdateScoreDisplay();
                    //Destroy(gameObject);
                }
            }

            //fadeOut Coroutine
            //StartCoroutine(FadeOut(1f));
            //showPoint Coroutine
            //StartCoroutine(ShowPoint(transform.position));

            // Play the 'boink' audio clip
            if (boinkAudioSource != null)
            {
                boinkAudioSource.Play();
            }

        
        }

    }

    IEnumerator FadeOut(float fadeSpeed)
    {
        Renderer rend = gameObject.transform.GetComponent<Renderer>(); //obj
        Color matColor = rend.material.color; // get color
        float alphaValue = rend.material.color.a; // alpha val
        Quaternion rot = gameObject.transform.rotation; //To keep rotation when fading

        while (rend.material.color.a > 0f) // while not transparent
        {
            //Not sure why but they go to prefab rotation when fading so
            //this line here to keep them facing same direction
            gameObject.transform.rotation = rot; //Keep rotation when fading
            alphaValue -= Time.deltaTime / fadeSpeed; // decrease tranparency
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);// change color
            yield return null;
        }
        rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);

        if (destroyGameObject){
            Destroy(gameObject); // destroy if box checked
        }
    }

    IEnumerator ShowPoint(Vector3 position)
    {

        GameObject p = Instantiate(pointPrefab, position,
            Quaternion.identity, transform);
        p.transform.SetParent(transform, false);

        yield return null;
    }
}
