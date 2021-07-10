using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {


	public void RetryTriUse()
	{
		SceneManager.LoadScene (11);

		GameManager.scoreCount = 0;
		GameManager.NumberLives = 3;

	}

	public void RetrySIF()
	{
		SceneManager.LoadScene (8);

		SIF_Manager.scoreCount = 0;
		SIF_Manager.NumberLives = 3;
	}

	public void RetryPaperCycle()
	{
		SceneManager.LoadScene (22);

		PaperCycleManager.scoreCount = 0;
		PaperCycleManager.NumberLives = 1;

		PaperCycleManager2.scoreCount = 0;
		PaperCycleManager2.NumberLives = 1;

		PaperCycleManager3.scoreCount = 0;
		PaperCycleManager3.NumberLives = 1;

	}

}
