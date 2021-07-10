using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	public Text showText;
	public Text showHighScoreText;

	public static int highScore;
	public static int showScore;

	public Text showName; //add
	public Text showNameText; //add
	 
	public static string HighName; //add
	public static string CurrentName; //add

	void Start()
	{
		CurrentName = EnterName.nameString; //add
		HighName = PlayerPrefs.GetString ("highString", HighName);//add

		showScore = MainGameScore.mainScore;
		highScore = PlayerPrefs.GetInt ("highScore", highScore);
		showHighScoreText.text = highScore.ToString();
	}

	void Update()
	{
		showText.text = " " + showScore;
		HighScore ();


		showName.text = " " + CurrentName; //add
		showNameText.text = " " + HighName; //add
	}

	void HighScore ()
	{
		if (showScore > highScore) {
		
			HighName = CurrentName; //add
			showNameText.text = "" + HighName; //add

			highScore = showScore;
			showHighScoreText.text = "" + highScore;

			PlayerPrefs.SetString ("highString", HighName);//add

			PlayerPrefs.SetInt ("highScore", highScore);

		}

	}


		



}
