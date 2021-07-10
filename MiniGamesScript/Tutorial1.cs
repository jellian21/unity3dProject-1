using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial1 : MonoBehaviour {

	public Canvas Image1;
	public Canvas Image2;
	public Canvas Image3;
	public Canvas Image4;
	public Canvas Image5;
	public Canvas Image6;


	void Start()
	{
		
		Image1.enabled = true;
		Image2.enabled=false;
		Image3.enabled=false;
		Image4.enabled=false;
		Image5.enabled=false;
		Image6.enabled=false;
	}

	public void Next1()
	{
		Image1.enabled=false;
		Image2.enabled=true;
		Image3.enabled=false;
		Image4.enabled=false;
		Image5.enabled=false;
		Image6.enabled=false;
	}

	public void Next2()
	{
		Image1.enabled=false;
		Image2.enabled=false;
		Image3.enabled=true;
		Image4.enabled=false;
		Image5.enabled=false;
		Image6.enabled=false;
	}
	public void Next3()
	{
		Image1.enabled=false;
		Image2.enabled=false;
		Image3.enabled=false;
		Image4.enabled=true;
		Image5.enabled=false;
		Image6.enabled=false;
	}
	public void Next4()
	{
		Image1.enabled=false;
		Image2.enabled=false;
		Image3.enabled=false;
		Image4.enabled=false;
		Image5.enabled=true;
		Image6.enabled=false;
	}
	public void Next5()
	{
		Image1.enabled=false;
		Image2.enabled=false;
		Image3.enabled=false;
		Image4.enabled=false;
		Image5.enabled=false;
		Image6.enabled=true;
	}




	public void Last()
	{
		SceneManager.LoadScene (14);	
	}
	public void Last2()
	{
		SceneManager.LoadScene (18);	
	}
	public void Last3()
	{
		SceneManager.LoadScene (19);	
	}
}
