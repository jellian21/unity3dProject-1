using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour {

	public Canvas MainCanvas;
	public Canvas SettingsCanvas;
	public Transform MusicPrefab;
	private AudioSource audio;


	void Start () {

		if (!GameObject.FindGameObjectWithTag("MM")) 
		{
			Transform MManager = Instantiate (MusicPrefab, transform.position, Quaternion.identity)
				as Transform;
			MManager.name= MusicPrefab.name;
			DontDestroyOnLoad (MManager);
		}
	}
	void Awake()

	{
		MainCanvas.enabled = true;
		SettingsCanvas.enabled = false;;
	}

	public void SettingsOn()
	{
		SettingsCanvas.enabled = true;
		MainCanvas.enabled = false;
	}

	public void ReturnOn()
	{
		SettingsCanvas.enabled = false;
		MainCanvas.enabled = true;
	
	}

	public void LoadOn()
	{
		Application.LoadLevel (2);
	}
	public void ExitOn()
	{
		Application.Quit ();

	}
	/*
	bool toggle;
	public void sound()
	{
		GameObject thesound = GameObject.FindGameObjectWithTag ("MM");
		AudioSource theaudio = thesound.GetComponent<AudioSource> ();

		if (toggle == false) {
			theaudio.mute=true;
		} else if(toggle==true) {
			//theaudio.UnPause ();
			theaudio.mute=false;
		}
	}
*/
}
