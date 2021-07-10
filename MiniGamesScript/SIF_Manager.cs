using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SIF_Manager : MonoBehaviour {
	

	public TrashObject[] trashlist;
	private static List<TrashObject> unansweredObject;
	private TrashObject currentObject;

	//Caption
	//public TrashObject[] captionList;
	//private static List<TrashObject> notCaptionList;
	//private TrashObject currentCaption;

	private float timedelay=1f;

	public Text livesText;
	public Text score;


	public static int scoreCount;
	private  static int point=1;
	public static int NumberLives=3;
	private static int deduct = 1;

	public Animator anim;

	[SerializeField]
	public Image ImageProject;

	//Caption
	[SerializeField]
	public Text captionProject;

	//sound effect
	public AudioSource correct;
	public AudioSource wrong;
	public AudioSource warning;

	public AudioClip correctSound;
	public AudioClip wrongSound;
	public AudioClip warningSound;

	//public GameObject Score;
	//public Transform MusicPrefab;
	//private AudioSource audio;


	void Start () {

		TimerMiniGames.timeClock = 10.0f;
		anim = GetComponent<Animator> ();
//		score = GetComponent<Text> ();
		/*
		if (!GameObject.FindGameObjectWithTag("MM")) 
		{
			Transform MManager = Instantiate (MusicPrefab, transform.position, Quaternion.identity)
				as Transform;
			MManager.name= MusicPrefab.name;
			DontDestroyOnLoad (MManager);
		}*/

		//anim = GetComponent<Animator> ();

		if (unansweredObject == null || unansweredObject.Count == 0) 
		{
			unansweredObject=trashlist.ToList<TrashObject>();

		}

		//if (notCaptionList == null || notCaptionList.Count == 0) 
		//{
		//	notCaptionList = captionList.ToList<TrashObject> ();
		//}

		setRandomObject ();
			

	}

	void Update()
	{
		PlayWarning ();
	}

	void setRandomObject()
	{
		int randomObjectIndex = Random.Range (0, unansweredObject.Count);

		currentObject = unansweredObject [randomObjectIndex];
		ImageProject.sprite= currentObject.trashimage;
		unansweredObject.RemoveAt (randomObjectIndex);

		//Caption
		//currentCaption=notCaptionList[randomObjectIndex];
		captionProject.text = currentObject.caption;
		//notCaptionList.RemoveAt (randomObjectIndex);

		scoreEnable();
		PlayerLife();
		IsWin ();

	

	}

	IEnumerator NextObject()
	{
				
		unansweredObject.Remove (currentObject);
		//notCaptionList.Remove (currentCaption);

		yield return new WaitForSeconds (timedelay);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);


	}


	void IsWin()
	{
		if (scoreCount >= 5) {
			MainGameScore.mainScore += scoreCount;
			SceneManager.LoadScene (9);
			scoreCount = 0;
		} 
	
	}

	public void UserSelectBio()
	{
		
		if (currentObject.bio)
		{

			anim.SetBool ("Correct", true);
			anim.SetBool ("Wrong", false);
			ScoreIncrease ();
		}
		else
		{

			anim.SetBool ("Wrong", true);
			anim.SetBool ("Correct", false);
			ScoreDecrease ();
		}

		StartCoroutine (NextObject ());
	}

	public void UserSelectNonBio()
	{
		
		
		if (currentObject.nonbio)
		{

			anim.SetBool ("Correct", true);
			anim.SetBool ("Wrong", false);
			ScoreIncrease ();
		}
		else
		{
	
			anim.SetBool ("Wrong", true);
			anim.SetBool ("Correct", false);
			ScoreDecrease ();
			
		}
		StartCoroutine (NextObject ());
	}
	public void UserSelectHazard()
	{

		if (currentObject.hazard)
		{

		
			anim.SetBool ("Correct", true);
			anim.SetBool ("Wrong", false);
			ScoreIncrease ();
		}
		else
		{
			
			anim.SetBool ("Wrong", true);
			anim.SetBool ("Correct", false);
			ScoreDecrease ();
			
		}
		StartCoroutine (NextObject ());
	}

	public void ScoreIncrease()
	{
		correct.clip = correctSound;
		correct.Play ();

		//correct= GetComponent<AudioSource> ();
		//correct.PlayOneShot (correctSound);

		scoreCount+=point;
		score.text = "Score: " + scoreCount;


	}
	public void ScoreDecrease()
	{
		wrong.clip = wrongSound;
		wrong.Play ();

		//wrong = GetComponent<AudioSource> ();
		//wrong.PlayOneShot (wrongSound);

		if (NumberLives>0 ) {

			if (scoreCount>0)
			{
				NumberLives -= deduct;
				//scoreCount -= point;
				score.text = "Score: " + scoreCount;
				PlayerLife ();
			}
			else
			{
				NumberLives -= deduct;
				PlayerLife();
			}


		}
		else {
			PlayerLife ();
		}
	}

	public void PlayerLife()
	{

		livesText.text = "Lives:" + NumberLives;

		if (NumberLives <= 0 ) {
			SceneManager.LoadScene (10);
			NumberLives = 3;
		
		}
	}
	public void scoreEnable()
	{

		score.text = "Score: " + scoreCount;
	}

	//delete

	public void PlayWarning()
	{
		if (TimerMiniGames.timeClock < 4) 
		{

			warning.clip = warningSound;
			warning.Play ();
			//warning.PlayOneShot (warningSound);
		}

	}


}
