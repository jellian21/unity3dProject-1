using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour {

	public void PlayerWinProceed()
	{
		SceneManager.LoadScene (3);
	}



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
		SceneManager.LoadScene (14);
		PaperCycleManager.scoreCount = 0;
		PaperCycleManager.NumberLives = 3;
	}
}
