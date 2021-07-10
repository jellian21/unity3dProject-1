using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;


public class PaperCycleManager : MonoBehaviour {

	public OrigamiImage[] origamiList;
	private static List <OrigamiImage> notAnswered;
	private OrigamiImage currentOrigami;

	//expected Origami
	public OrigamiImage[] expectedList;
	private static List <OrigamiImage> notExpected;
	private OrigamiImage currentExpectation;


	public Canvas GameCanvas;
	public Canvas FinishCanvas;

	private float timedelay=1f;
	public static int NumberLives=1;
	private static int deduct = 1;
	public static int scoreCount;
	private  static int point=1;

	public Text score;
	public Text livesText;


	//sound effect
	public AudioSource correct;
	public AudioSource wrong;

	public AudioClip correctSound;
	public AudioClip wrongSound;


	private AudioSource audio;
	public Transform MusicPrefab;

	[SerializeField]
	public Image OrigamiProject;

	//expected origami
	[SerializeField]
	public Image ExpectedProject;



	void Awake()
	{
		GameCanvas.enabled = true;
		FinishCanvas.enabled = false;

	}


	void Start()
	{
		TimerMiniGamesPaperCycle.timeClock = 10.0f;
		/*
		if (!GameObject.FindGameObjectWithTag("MM")) no
		{
			Transform MManager = Instantiate (MusicPrefab, transform.position, Quaternion.identity)
				as Transform;
			MManager.name= MusicPrefab.name;
			DontDestroyOnLoad (MManager);
		}
		*/

		//expected origami
		if (notExpected == null || notExpected.Count == 0) {
			notExpected = origamiList.ToList<OrigamiImage>();
		}

		if (notAnswered == null || notAnswered.Count == 0) {
			notAnswered = origamiList.ToList<OrigamiImage>();
		}
		setOrigami ();

	}

	void setOrigami()
	{
		int index = Random.Range (0, 0);

		//int randomObjectIndex = Random.Range (0, notAnswered.Count);
		currentOrigami = notAnswered[index];
		OrigamiProject.sprite = currentOrigami.origamiSprite;
		notAnswered.RemoveAt (index);

		//expected origami
		currentExpectation = notExpected [index];
		ExpectedProject.sprite = currentExpectation.expectedSprite;
		notExpected.RemoveAt (index);

		scoreEnable();
		PlayerLife();
	//	IsWin ();
		IfComplete();
		TimerMiniGames.timeClock = 10;
	}

	IEnumerator NextOrigami()
	{
		notAnswered.Remove (currentOrigami);
		notExpected.Remove (currentExpectation);

		yield return new WaitForSeconds (timedelay);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}


	public void UserSelectOne()
	{
		if (currentOrigami.one) {
		
			ScoreIncrease ();
		}
		else {
			ScoreDecrease ();
		}

		StartCoroutine (NextOrigami ());
	}

	public void UserSelectTwo()
	{
		if (currentOrigami.two) {

			ScoreIncrease ();
		}
		else {
			ScoreDecrease ();
		}

		StartCoroutine (NextOrigami ());
	}


	public void ScoreIncrease()
	{
		correct.clip = correctSound;
		correct.Play ();

		scoreCount+=point;
		score.text = "Score: " + scoreCount;


	}
	public void ScoreDecrease()
	{
		wrong.clip = wrongSound;
		wrong.Play ();

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
			SceneManager.LoadScene (16);

			notAnswered.Clear ();
			notExpected.Clear ();
		}
	}
	public void scoreEnable()
	{

		score.text = "Score: " + scoreCount;
	}

	// check if the player completed the mini-game
	public void IfComplete()
	{
		
		if (scoreCount == 5) {
			
			FinishCanvas.enabled = true;
			GameCanvas.enabled = false;

		}
	}


	public void Proceed()
	{
		MainGameScore.mainScore += scoreCount;
		SceneManager.LoadScene (3);
		scoreCount = 0;
		notAnswered.Clear ();
		notExpected.Clear ();
	
	}
}
