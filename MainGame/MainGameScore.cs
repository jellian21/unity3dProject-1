using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameScore : MonoBehaviour {

	public Text scoreText;
	public Text LifeText;
	public Text mainScoreText;

	public static int life=3;
	public static int score=0;
	public static int point=1;
	public static int mainScore=0;



	void Update()
	{

		LifeText.text = "Lives: " + life;
		scoreText.text = "Students: " + score;
		mainScoreText.text = "Score: " + mainScore;


		if (score >= 3) {
			SceneManager.LoadScene (6);
			score=0;
		
		}

		if (life <= 0) {
			SceneManager.LoadScene (17);

		}
	}

}
