using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public TriUseQuestion[] questions;  

	public Text score;
	public Text livesText;


	public static int scoreCount;
	private static int pointperquestion = 1;
	public bool isplaying;
	public static int NumberLives=3;
	private static int deduct = 1;

	private static List<TriUseQuestion> notanswered;

	private TriUseQuestion currentquestion;

	//sound effect
	public AudioSource correctSource;
	public AudioSource wrongSource;
	public AudioSource warning;

	public AudioClip correctClip;
	public AudioClip wrongClip;
	public AudioClip warningSound;



	[SerializeField]
	private Text factText;
	[SerializeField]
	private Text yesAnswer;
	[SerializeField]
	private Text noAnswer;
	[SerializeField]
	public Animator anim; 

	private float timedelay=1f;

	//public Transform MusicPrefab;

	void Start()
	{
	
		TimerMiniGamesTriUse.timeClock = 10.0f;
		/*
		//for audio
		if (!GameObject.FindGameObjectWithTag("MM")) 
		{
			Transform MManager = Instantiate (MusicPrefab, transform.position, Quaternion.identity)
				as Transform;
			MManager.name= MusicPrefab.name;
			DontDestroyOnLoad (MManager);
		}
		*/
	//	score = GetComponent<Text> ();
	//	anim = GetComponent<Animator> ();
		if (notanswered == null || notanswered.Count==0)
		{
			notanswered=questions.ToList<TriUseQuestion>();
		}
	

		SetCurrentQuestion ();
		isplaying = true;

	}

	void Update()
	{
		PlayWarning ();
	}

	void SetCurrentQuestion()
	{
		int randomQuestionIndex = Random.Range (0, notanswered.Count);
		currentquestion = notanswered [randomQuestionIndex];

		factText.text=currentquestion.fact;

		if (currentquestion.isTrue) {
		
			yesAnswer.text = "Correct";
			noAnswer.text = "Wrong";

	
		} else {
			yesAnswer.text = "Wrong";
			noAnswer.text = "Correct";
		}
		//StartCoroutine (IsWin ());
		scoreEnable();
		PlayerLife();
		IsWin();


	}

	IEnumerator NextQuestion()
	{

		notanswered.Remove(currentquestion);

		yield return new WaitForSeconds (timedelay);
		score.enabled = true;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

		//sscoreCount+=pointperquestion;
		//score.text = "Score: " + scoreCount;

	}
	void IsWin()
	{
		if (scoreCount >= 5) {

			MainGameScore.mainScore += scoreCount;
			SceneManager.LoadScene (12);
			scoreCount = 0;
		} 

	}


	public void UserSelectYes()
	{
		anim.SetTrigger ("yes");

		if (currentquestion.isTrue) {
			//score
			//scoreCount+=pointperquestion;
		//	score.text = "Score: " + scoreCount;
			ScoreIncrease();

		}
		else 
		{
			//scoreCount-=pointperquestion;
		//	score.text = "Score: " + scoreCount;
			ScoreDecrease();

		}
		/*
		if (scoreCount == 3) 
		{
			anim.SetTrigger ("win");
			yield return new WaitForSeconds (2);

		}

*/
		StartCoroutine (NextQuestion ());
	}
	public void UserSelectNo()
	{
		
		anim.SetTrigger ("no");
		if (currentquestion.isTrue) {

			//score
		//	scoreCount-=pointperquestion;
		//	score.text = "Score: " + scoreCount;
			ScoreDecrease();

		} 
		else 
		{
			//scoreCount+=pointperquestion;
		//	score.text = "Score: " + scoreCount;
			ScoreIncrease();
		
		}



		StartCoroutine (NextQuestion ());

	}

	public void ScoreIncrease()
	{
		correctSource.clip = correctClip;
		correctSource.Play ();

		scoreCount+=pointperquestion;
		score.text = "Score: " + scoreCount;


	}
	public void ScoreDecrease()
	{
		wrongSource.clip = wrongClip;
		wrongSource.Play ();

		if (NumberLives>0 ) {

			if (scoreCount>0)
			{
			NumberLives -= deduct;
			//scoreCount -= pointperquestion;
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
			SceneManager.LoadScene (13);
			NumberLives = 3;
		}
	}
	public void scoreEnable()
	{
		
		score.text = "Score: " + scoreCount;
	}
	public void PlayWarning()
	{
		if (TimerMiniGamesTriUse.timeClock < 4) 
		{

			warning.clip = warningSound;
			warning.Play ();
			//warning.PlayOneShot (warningSound);
		}

	}

}
