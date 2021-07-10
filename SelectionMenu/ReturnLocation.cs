using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnLocation : MonoBehaviour {

	public void returnLocation()
	{

		SceneManager.LoadScene (3);
	}

	public void returnMiniGames()
	{

		SceneManager.LoadScene (6);
	}

	public void returnPaperCycle()
	{
		SceneManager.LoadScene (22);

	}

}
