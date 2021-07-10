using UnityEngine;
using System.Collections;

public class RandomEatingSpeed : MonoBehaviour {

	public Animator anim;
	public float eatingSpeed;
	public float NoteatingSpeed;

	void Awake()
	{
		anim = GetComponent<Animator> ();

	}

	void Update()
	{
		StartCoroutine (StopEating ());

		StartCoroutine (Eating ());



	}

	IEnumerator StopEating()
	{

		yield return new WaitForSeconds(NoteatingSpeed);
		anim.SetBool ("Eat", false);
		anim.SetBool ("Pause", true);
	}
	IEnumerator Eating()
	{

		yield return new WaitForSeconds(eatingSpeed);
		anim.SetBool ("Eat", true);
		anim.SetBool ("Pause", false);
	}
}
