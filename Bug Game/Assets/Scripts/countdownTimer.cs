using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 45f;
	public string textValue = "Timer: ";
	public TextMeshProUGUI textElement;
	public StateLoader stateloader;

	// Start is called before the first frame update
	void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime == 3f) { 
			//3 2 1
        }
		currentTime -= 1 * Time.deltaTime;
		textElement.text = textValue + ((int)System.Math.Round(currentTime)).ToString();
		if (currentTime <= 0)
		{
			//	TIMES UP animation
			NextState();

		}
	}

	public void NextState()
	{
		StartCoroutine(LoadState(SceneManager.GetActiveScene().buildIndex + 1));
	}

	IEnumerator LoadState(int sceneIndex)
	{
		yield return new WaitForSeconds(0);
		SceneManager.LoadScene(sceneIndex);
	}
}
