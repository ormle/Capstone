using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;
	public string textValue = "Timer: ";
	public TextMeshProUGUI textElement;
	public TextMeshProUGUI timesUp;
	public StateLoader stateloader;
	public Image timerBar;

	// Start is called before the first frame update
	void Start()
    {
		timesUp.enabled = false;
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime == 3f) { 
			//3 2 1
        }
		currentTime -= 1 * Time.deltaTime;
		timerBar.fillAmount = currentTime / startingTime;
		textElement.text = textValue + ((int)System.Math.Round(currentTime)).ToString();
		if (currentTime <= 0)
		{
			timesUp.enabled = true;
			Time.timeScale = 0;
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
		yield return new WaitForSecondsRealtime(2f);
		SceneManager.LoadScene(sceneIndex);
		Time.timeScale = 1;
	}
}
