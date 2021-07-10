using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public Text timerText;
	public float timeClock=60.0f;
	//private static int counter=0;

	//void Start()
	//{


	//	if (counter >= 1) {
	//		timeClock -=10;
	//	}
	//	counter++;
	//}


	void Update()
	{
		timeClock -= Time.deltaTime;
		timerText.text = "Time: " + Mathf.Round (timeClock);

		if (timeClock < 0) 
		{
			SceneManager.LoadScene (17);

		}




	}

}
