using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationMenu : MonoBehaviour {

	public Canvas LocationCanvas;

	void Awake()
	{
		LocationCanvas.enabled = true;
	}

	public void LocationOne ()
	{
		Application.LoadLevel(7);

	}
	public void LocationTwo ()
	{
		Application.LoadLevel (5);
	}
	public void LocationThree ()
	{
		Application.LoadLevel (4);
	}
	public void Return ()
	{
		Application.LoadLevel (1);
		MainGameScore.score = 0;
		MainGameScore.life = 3;
		MainGameScore.mainScore = 0;
	}

}
