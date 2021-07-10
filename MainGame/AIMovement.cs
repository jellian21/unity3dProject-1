using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class AIMovement : MonoBehaviour {

	public float speed=5;
	public float direction=1;
	public float headingchange=90;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;



	void Awake()
	{

		controller = GetComponent<CharacterController> ();
		heading = Random.Range (0, 90);
	
		transform.eulerAngles = new Vector3 (0, heading, 0);
	


		StartCoroutine (NewHeading ());
	}
	void Update()
	{
		//frontDir = true;
		//anim.SetBool ("forward", frontDir);
	

		transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, targetRotation, Time.deltaTime );
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove (forward* speed);

	}


	IEnumerator NewHeading()
	{
		while (true) {
			

			NewHeadingRoutine();
			yield return new WaitForSeconds(direction);
			}
			}
		

	void NewHeadingRoutine()
	{
		var floor = transform.eulerAngles.y - headingchange;
		var ceil = transform.eulerAngles.y + headingchange;
		heading = Random.Range (floor, ceil);
		targetRotation = new Vector3 ( 0,heading, 0);


	}
	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Wall"||col.gameObject.tag == "Student") {
			
		//	NewHeadingRoutine();
		}

	}



}
