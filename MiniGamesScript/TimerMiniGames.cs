using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerMiniGames : MonoBehaviour {

	//segre is fun timer
	public Text timerText;
	public static float timeClock=10.0f;

	void Update()
	{
		timeClock -= Time.deltaTime;
		timerText.text = "Time: " + Mathf.Round (timeClock);

		if (timeClock < 0) 
		{
			SceneManager.LoadScene (10);

		}
	


	}
}
