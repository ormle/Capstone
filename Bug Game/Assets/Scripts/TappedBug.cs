using UnityEngine;
using TouchScript.Gestures;
using System;
using System.Collections;


public class TappedBug : MonoBehaviour
{
    private AudioSource boinkAudioSource; // Reference to the 'boink' AudioSource
    public bool destroyGameObject = true; // MAKE
    public GameObject pointPrefab;

    void Start()
    {
        TapGesture tapGesture = this.GetComponent<TapGesture>();

        tapGesture.Tapped += TapGesture_Tapped;

        // Find the 'boink' AudioSource by name in the scene
        boinkAudioSource = GameObject.Find("boink").GetComponent<AudioSource>();
        

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
                    StartCoroutine(ShowPoint(transform.position)); // Point animation coroutine
                    StartCoroutine(FadeOut(1f)); // fadeOut Coroutine
                    scoreManager.AddScore(1);
		    scoremanager.BugCounter(2);
                    
                    //Debug.Log("anim should happe");
                    //Destroy(this.gameObject);

				}
				if (this.name == "ButterflyTemp" || this.name == "ButterflyTemp(Clone)")
				{
                    this.GetComponent<MoveCurve>().Speed = 0f;
                    StartCoroutine(ShowPoint(transform.position));
                    scoreManager.AddScore(5);
		    scoremanager.BugCounter(4);
                    StartCoroutine(FadeOut(1f));
                    //Destroy(gameObject);
				}
				if (this.name == "DragonflyTest" || this.name == "DragonflyTest(Clone)")
				{
                    this.GetComponent<MoveZigZag>().speed = 0f;
                    StartCoroutine(ShowPoint(transform.position));
                    scoreManager.AddScore(8);
		    scoremanager.BugCounter(5);
                    StartCoroutine(FadeOut(1f));
                    //Destroy(gameObject);
				}
				if (this.name == "BeeTemp" || this.name == "BeeTemp(Clone)")
				{
                    this.GetComponent<MoveCurve>().Speed = 0f;
                    StartCoroutine(ShowPoint(transform.position));
                    scoreManager.AddScore(10);
		    scoremanager.BugCounter(3);
                    StartCoroutine(FadeOut(1f));
                    //Destroy(gameObject);
				}
				ShowScore showScore = FindObjectOfType<ShowScore>();
                if (showScore != null)
                {
                    showScore.UpdateScoreDisplay();
                    //Destroy(gameObject);
                }
            }

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
            Quaternion.identity);
        p.transform.SetParent(transform, false);

        yield return null;
    }
}
