using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterName : MonoBehaviour {

	public static string nameString;
	public Text nameText;
	void Start()
	{
		//	nameString = GameObject.Find ("NameText").GetComponent();	

	}

	public void characterField()
	{
		nameString = nameText.text.ToString ();
		Debug.Log(nameString);
	}

	public void Enter()
	{
		//PlayerPrefs.SetString ("nameString", nameString);
		SceneManager.LoadScene (3);

	}
}
