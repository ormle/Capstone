using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    float startingTime = 20f;
	public string textValue = "Timer: ";
	public TextMeshProUGUI textElement;
	public TextMeshProUGUI timesUp;
	public StateLoader stateloader;
	public Image timerBar;
	public GameObject banner;

	// Start is called before the first frame update
	void Start()
    {
		//banner.SetActive(false);
		timesUp.enabled = false;
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime == 3f) { 
			//3 2 1
			//Debug.Log("here");
        }
		currentTime -= 1 * Time.deltaTime;
		//Debug.Log("current time:" + currentTime);
		timerBar.fillAmount = currentTime / startingTime;
		textElement.text = textValue + ((int)System.Math.Round(currentTime)).ToString();
		if (currentTime <= 13) {
			banner.transform.position += -transform.right * 5 * Time.deltaTime;
			//transform.position += transform.forward * speed * Time.deltaTime;		
			//print("HERE!!!!!!!!!!!!!!!!!") ;
		}
		if (currentTime <= 0)
		{
			// Debug.Log("current time:" + currentTime);
			timesUp.enabled = true;
			banner.SetActive(false);
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
