using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class WanderForViolator : MonoBehaviour {

	public float speed = 5;
	public float directionChangeInterval = 1;
	public float maxHeadingChange = 30;

	int dirX=0;
	int dirZ=0;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;
//	Rigidbody Rb;

	Vector3 forward
	{
		get { return transform.TransformDirection(Vector3.forward); }
	}

	void Awake ()
	{
	//	Rb = GetComponent<Rigidbody> ();
		controller = GetComponent<CharacterController>();

		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(dirX, heading, dirZ);


		StartCoroutine(NewHeadingRoutine());
	}

	void Update ()
	{

		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		controller.SimpleMove(forward * speed);
		//


		//lock rotation
		transform.rotation = Quaternion.Euler (dirX,transform.rotation.eulerAngles.y, dirZ);
	}

	void OnControllerColliderHit (ControllerColliderHit hit)
	{
	//	if (hit.gameObject.tag != "Wall"||hit.gameObject.tag != "Student"||hit.gameObject.tag != "Violator") {

		if (hit.gameObject.tag == "Wall"||hit.gameObject.tag == "Student"||hit.gameObject.tag == "Violator") {
			
			//NewHeading();
		

		// Bounce off the wall using angle of reflection
		var newDirection = Vector3.Reflect(forward, hit.normal);

		transform.rotation = Quaternion.FromToRotation(Vector3.forward, newDirection);
		heading = transform.eulerAngles.y;
		NewHeading();

			return;
		}
			//exit!
		if (hit.gameObject.tag == "Door"&& gameObject.gameObject.tag=="Violator") {
			Destroy (this.gameObject);
		}

	}

	/// <summary>
	/// Calculates a new direction to move towards.
	/// </summary>
	void NewHeading ()
	{
		var floor = transform.eulerAngles.y - maxHeadingChange;
		var ceil  = transform.eulerAngles.y + maxHeadingChange;
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(dirX, heading, dirZ);
	}

	/// <summary>
	/// Repeatedly calculates a new direction to move towards.
	/// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
	/// </summary>
	IEnumerator NewHeadingRoutine ()
	{
		while (true) {
			NewHeading();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}

}