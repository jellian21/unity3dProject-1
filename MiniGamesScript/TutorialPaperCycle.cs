using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialPaperCycle : MonoBehaviour {

	public Canvas Tutorial1;
	public Canvas Tutorial2;

	void Start () {
	
		Tutorial1.enabled=true;
		Tutorial2.enabled=false;

	}

	public void Next()
	{
		Tutorial1.enabled = false;
		Tutorial2.enabled = true;

	}
}
