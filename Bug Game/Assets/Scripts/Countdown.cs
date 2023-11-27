using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdown;
    public AudioSource threeSound;
	public AudioSource twoSound;
	public AudioSource oneSound;
	public GameObject lapTimer;

	public void Start() {
		Time.timeScale = 0;
		StartCoroutine(CountdownCoroutine());
	}

	IEnumerator CountdownCoroutine() {
		countdown.text = "3";
		//threeSound.Play();

		yield return new WaitForSecondsRealtime(1f);
		countdown.text = "";
		countdown.text = "2";
		//twoSound.Play();

		yield return new WaitForSecondsRealtime(1f);
		countdown.text = "";
		countdown.text = "1";
		//oneSound.Play();

		yield return new WaitForSecondsRealtime(1f);
		countdown.text = "";
		countdown.text = "GO";
		//threeSound.Play();

		yield return new WaitForSecondsRealtime(1f);
		countdown.enabled = false;
		Time.timeScale = 1;

	}
}
