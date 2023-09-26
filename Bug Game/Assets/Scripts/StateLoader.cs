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
		if (Input.GetMouseButtonDown(0))
		{
			LoadPlayState();
		}
	}


	public void LoadPlayState()
	{
		StartCoroutine(LoadState(SceneManager.GetActiveScene().buildIndex + 1));
	}

	//Creating coroutine??
	IEnumerator LoadState(int sceneIndex)
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(sceneIndex);
	}

}