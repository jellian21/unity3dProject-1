using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MiniGamesTutorial : MonoBehaviour {
		

	public void StartSIF()
	{
		SceneManager.LoadScene (8);
	}

	public void StartTriUse()
	{
		SceneManager.LoadScene (11);
	}
	public void StartPaperCycle()
	{
		SceneManager.LoadScene (22);
	}
	public void StartMainGame()
	{
		SceneManager.LoadScene (32);
	}
}
