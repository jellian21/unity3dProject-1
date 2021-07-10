using UnityEngine;
using System.Collections;

public class MiniGamesSelection : MonoBehaviour {

	public Canvas MiniGameCanvas;

	void Awake()
	{
		MiniGameCanvas.enabled = true;
	}

	public void SegreIsFun ()
	{
		Application.LoadLevel(23);

	}
	public void TriUse ()
	{
		Application.LoadLevel (24);
	}
	public void PaperCycle ()
	{
		Application.LoadLevel (25);
	}
}
