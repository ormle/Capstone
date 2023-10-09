using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;

public class TappedBug : MonoBehaviour
{
	// public Image bug;
	//public ShowScore score = ShowScore();

    void Start()
	{
		TapGesture tapGesture = this.GetComponent<TapGesture>();
		tapGesture.Tapped += TapGesture_Tapped;
	}


	void TapGesture_Tapped(object sender, System.EventArgs e)
	{

		// bug.CrossFadeAlpha(0,10,true) ;
		//score.AddScore(1);
		Destroy(gameObject);
		//Debug.Log("bug gone");
	}

}
