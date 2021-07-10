using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainGameOver : MonoBehaviour {

	public void MainGameRetry()
	{
		SceneManager.LoadScene (3);

		//restore all data back to zero
		MainGameScore.life = 3;
		MainGameScore.score=0;
		MainGameScore.mainScore = 0;
	}

	public void ExitGame()
	{
		SceneManager.LoadScene (1);	

		//restore all data back to zero
		MainGameScore.life = 3;
		MainGameScore.score=0;
		MainGameScore.mainScore = 0;
	}



}
