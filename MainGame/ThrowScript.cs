using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ThrowScript : MonoBehaviour {
	/*
	Transform rocket;
	float power = 10;
	float reload = 5;
	float time = 5.0f;
	private float next = 0.0f;
	private float timestamp = -5.0f;

	void Update ()
	{
		if (Time.time > next) {
			timestamp = Time.time;
			Throw ();
		}
	}
	IEnumerator Throw () {

		yield return new WaitForSeconds(1);
		var clone=Instantiate (rocket, transform.position, transform.rotation);
	}*/

	//public Transform Target;
	//public float firingAngle = 45.0f;
	//public float gravity = 9.8f;

	public Transform character;
//	public Transform Projectile;      
	public Rigidbody Projectile;

	public int repeaTime;

	public float force;

	void Awake()
	{
		
	//	myTransform = transform;    

	}

	void Start()
	{          
		repeaTime = Random.Range (3, 6);
		InvokeRepeating ("Throw", repeaTime, repeaTime);
		//StartCoroutine(SimulateProjectile());
	}

	/*
	IEnumerator SimulateProjectile()
	{
		// Short delay added before Projectile is thrown
		yield return new WaitForSeconds(1.5f);

		// Move projectile to the position of throwing object + add some offset if needed.
		Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

		// Calculate distance to target
		float target_Distance = Vector3.Distance(Projectile.position, Target.position);

		// Calculate the velocity needed to throw the object to the target at specified angle.
		float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad)
			/ gravity);

		// Extract the X  Y componenent of the velocity
		float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
		float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

		// Calculate flight time.
		float flightDuration = target_Distance / Vx;

		// Rotate projectile to face the target.
		Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

		float elapse_time = 0;

		while (elapse_time < flightDuration)
		{
			Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * 
				Time.deltaTime);

			elapse_time += Time.deltaTime;

			yield return null;
		}

		Instantiate(Projectile, character.position,character.rotation);
	}  */

	void Throw()
	{	

		//Projectile.GetComponent<Rigidbody> ().velocity = new Vector3 (transform.localScale.z, 5)*force;
	//	rB.velocity = new Vector3 (transform.localScale.x, 1);
		Instantiate(Projectile, character.position,character.rotation) ;	
		StartCoroutine (DestroyObject ());
	}





	IEnumerator DestroyObject()
	{
		int timeTrash = 2;
		yield return new WaitForSeconds (timeTrash);
		DestroyObject (GameObject.FindGameObjectWithTag ("Trash"));
	}

}



			


