using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class VideoTutorial : MonoBehaviour {

	public MovieTexture tutorial;
	public Transform MusicPrefab;
	private AudioSource audio;

	IEnumerator Start () 
	{
		
		if (!GameObject.FindGameObjectWithTag("MM")) 
		{
			Transform MManager = Instantiate (MusicPrefab, transform.position, Quaternion.identity)
				as Transform;
			MManager.name= MusicPrefab.name;
			DontDestroyOnLoad (MManager);
		}

		GetComponent<RawImage> ().texture = tutorial as MovieTexture;
		tutorial.Play();
		//audio.Play ();
		yield return new WaitForSeconds (21);
		Application.LoadLevel (26);



	}

	public void Skip()
	{
		Application.LoadLevel (26);
	}

}
