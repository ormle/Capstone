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
    
    private bool isTapped = false;

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
        
        if (!isTapped && Time.timeScale == 1)//Only be able to tap bugs during game time
        {
            if (scoreManager != null)
            {
                //Debug.Log(this.instance);
                if (this.name.Contains("TigerBeetle"))
                {
                    this.GetComponent<MoveForward>().speed = 0f; // stops bug movement
                    scoreManager.AddScore(1); //Add score
		    
		            if (this.name.Contains("Black")) {
			            scoreManager.BugCounter(8); }
		            else {
			            scoreManager.BugCounter(2); } //Bugcounter brown

                }
                if (this.name.Contains("BlueMorpho") ||
					this.name.Contains("ChristinaSulphur") ||
					this.name.Contains("WhiteAdmiral") ||
					this.name.Contains("Monarch"))
				{
                    //Debug.Log("butter");
                    this.GetComponent<MoveCurve>().Speed = 0f;
                    scoreManager.AddScore(5);
		    
		            if (this.name.Contains("BlueMorpho")) {
			            scoreManager.BugCounter(11); }
		            else if (this.name.Contains("Christina")) {
			            scoreManager.BugCounter(10); }
		            else if (this.name.Contains("White")) {
			            scoreManager.BugCounter(9); }
		            else if (this.name.Contains("Monarch")) {
			            scoreManager.BugCounter(4); }
                }
                if (this.name.Contains("Dragonfly") || 
                    this.name.Contains("CherryMeadow") ||
                    this.name.Contains("BlueDarner"))
				{
                    this.GetComponent<MoveZigZag>().speed = 0f;
                    // Completely stop dragonfly mvmt coroutine
                    // so if tap when rotating does not continue rotating
                    bugSpawner.StopCoroutine(Dmove);
                    scoreManager.AddScore(8);
		    
		            if (this.name.Contains("BlueDarner")) {
			            scoreManager.BugCounter(5); }
		            else if (this.name.Contains("Dragonfly")) {
			            scoreManager.BugCounter(12); }
		            else if (this.name.Contains("Cherry")) {
			            scoreManager.BugCounter(13); }

                }
                if (this.name.StartsWith("Bee")) //Cant use contains cause tigerBEEtle
				{
                    Debug.Log("bee");
                    this.GetComponent<MoveCurve>().Speed = 0f;
                    scoreManager.AddScore(10);
		            scoreManager.BugCounter(3);

                }
                if (this.name.Contains("Ladybug"))
                {
                    this.GetComponent<MoveForward>().speed = 0f;
                    scoreManager.AddScore(3);
		            if (this.name.Contains("Yellow")) {
			            scoreManager.BugCounter(7); }
		            else {scoreManager.BugCounter(1);}
                }
                if (this.name.Contains("Banner")) // deals with ants that pull banner
                {
                    
                    scoreManager.AddScore(1);
                    scoreManager.BugCounter(6);
                }
                if (this.name.Contains("Ant"))
                {
                    
                    this.GetComponent<MoveForward>().speed = 0f; 
                    scoreManager.AddScore(1);
                    scoreManager.BugCounter(6);
                }
                ShowScore showScore = FindObjectOfType<ShowScore>();
                if (showScore != null)
                {
                    showScore.UpdateScoreDisplay();
                    //Destroy(gameObject);
                }
            }

            //Tapped bug
            isTapped = true;
            //fadeOut Coroutine
            StartCoroutine(FadeOut(1f));
            //showPoint Coroutine
            StartCoroutine(ShowPoint(transform.position));

            // Play the 'boink' audio clip
            if (boinkAudioSource != null)
            {
                boinkAudioSource.Play();
            }
        }//End if

    }//End if

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
