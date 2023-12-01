using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateLoader : MonoBehaviour
{
	public Animator transition;
	public float transitionTime = 1f;

	// Update is called once per frame
	void Update()
	{
		/*if (Input.GetKey("right"))
		{
			NextState();
		}
		if (Input.GetKey("left"))
		{
			PreviousState();
		}*/

	}


	public void NextState()
	{
		StartCoroutine(LoadState(SceneManager.GetActiveScene().buildIndex + 1));
	}

	public void PreviousState()
	{
		StartCoroutine(LoadState(SceneManager.GetActiveScene().buildIndex - 1));
	}

	public void RestartState()
	{
		ScoreManager.instance.ResetScore();
		StartCoroutine(LoadState(1));
	}

	public void HomeState()
	{
		ScoreManager.instance.ResetScore();
		StartCoroutine(LoadState(0));
	}

	//Creating coroutine??
	public IEnumerator LoadState(int sceneIndex)
	{
		switch (sceneIndex)
		{
			case 0:
				transition.SetTrigger("Slide");
				break;
			case 1:
				transition.SetTrigger("Slide");
				break;
			case 2://Tutorial Scene
				transition.SetTrigger("Ready");
				break;
			case 3:
				yield return new WaitForSecondsRealtime(2f);
				transition.SetTrigger("EndGame");
				break;
		}
		if (Time.timeScale == 0) { Time.timeScale = 1; }
		
		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(sceneIndex);
		
	}

}