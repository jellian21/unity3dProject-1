using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	/*
	public AudioSource bgm;

	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	

	void changebgm (AudioClip music) 
	{
		if (bgm.name == music.name)
			return;
		bgm.Stop ();
		bgm.clip = music;
		bgm.Play ();
	}
	*/

	public Transform MusicPrefab;

	void Start()
	{
		//for audio
		if (!GameObject.FindGameObjectWithTag("MM")) 
		{
			Transform MManager = Instantiate (MusicPrefab, transform.position, Quaternion.identity)
				as Transform;
			MManager.name= MusicPrefab.name;
			DontDestroyOnLoad (MManager);
		}




}

}

