using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class DespawnBug : MonoBehaviour
{
    // public Image bug;
    public ShowScore score = new ShowScore();

    void Start()
    {
        TapGesture tapGesture = this.GetComponent<TapGesture> () ;
        tapGesture.Tapped += TapGesture_Tapped ;
    }

    
    void TapGesture_Tapped (object sender, System.EventArgs e) {

		// bug.CrossFadeAlpha(0,10,true) ;
		score.AddScore(1);
		gameObject.SetActive(false);
        //Debug.Log("bug gone");
    }

}
