using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

	IEnumerator Start()
	{

		yield return new WaitForSeconds (3);
		Application.LoadLevel (1);
	}

	

}



	// Use this for initialization

	/*void Start () {
		
		yield WaitForSeconds (3);
		Application.LoadLevel (1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
*/