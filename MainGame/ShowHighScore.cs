using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour {

	public Text showNameText; //add
	public Text showHighScoreText;

	public static int highScore;
	public static string HighName; //add

	void Start()
	{
		HighName = PlayerPrefs.GetString ("highString"); //add
		showNameText.text = HighName.ToString (); //add
	
		highScore = PlayerPrefs.GetInt ("highScore", highScore);
		showHighScoreText.text = highScore.ToString ();
	}

	void Update()
	{
		HighScore ();
	}

	void HighScore ()
	{
		if (ShowScore.showScore > highScore) {

			HighName = ShowScore.CurrentName; //add
			showNameText.text = "" + HighName; //add

			highScore = ShowScore.showScore;
			showHighScoreText.text = "" + highScore;

			PlayerPrefs.SetInt ("highScore", highScore); //add

			PlayerPrefs.SetInt ("highScore", highScore);

		}
}
}