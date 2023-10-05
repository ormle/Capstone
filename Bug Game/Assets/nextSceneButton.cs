using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using UnityEngine.SceneManagement;

public class nextSceneButton : MonoBehaviour
{
	public StateLoader stateLoader = new StateLoader();
	// Start is called before the first frame update
	void Start()
	{
		TapGesture tapGesture = this.GetComponent<TapGesture>();
		tapGesture.Tapped += TapGesture_Tapped;
	}


	void TapGesture_Tapped(object sender, System.EventArgs e)
	{
		gameObject.SetActive(false); //here to check if the click is registering
		stateLoader.NextState();
		
	}
}
