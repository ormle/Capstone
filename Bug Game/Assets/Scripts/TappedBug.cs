using UnityEngine;
using TouchScript.Gestures;
using System;
using System.Collections;


public class TappedBug : MonoBehaviour
{
    private AudioSource boinkAudioSource; // Reference to the 'boink' AudioSource
    public bool destroyGameObject = true; // MAKE

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
                    
                    GetComponent<MoveForward>().speed = 0f; // stops bug movement
                    StartCoroutine(FadeOut(1f)); // fadeOut Coroutine
                    scoreManager.AddScore(1);
                    
                    //Debug.Log("anim should happe");
                    //Destroy(this.gameObject);

				}
				if (this.name == "ButterflyTemp" || this.name == "ButterflyTemp(Clone)")
				{
                    GetComponent<MoveCurve>().Speed = 0f;
                    scoreManager.AddScore(5);
                    StartCoroutine(FadeOut(1f));
                    //Destroy(gameObject);
				}
				if (this.name == "DragonflyTest" || this.name == "DragonflyTest(Clone)")
				{
                    GetComponent<MoveZigZag>().speed = 0f;
                    scoreManager.AddScore(8);
                    StartCoroutine(FadeOut(1f));
                    //Destroy(gameObject);
				}
				if (this.name == "BeeTemp" || this.name == "BeeTemp(Clone)")
				{
                    GetComponent<MoveCurve>().Speed = 0f;
                    scoreManager.AddScore(10);
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
}
