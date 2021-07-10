using UnityEngine;
using System.Collections;

public class OfficerCleanController : MonoBehaviour {

	public GameObject character;
	public int speed;

	void Update()
	{
//		Vector3 dir=new Vector3();
		float dirX=Input.GetAxisRaw("Horizontal");
		float dirY=Input.GetAxisRaw("Vertical");

		/*if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (0, -1.3f,0);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (0, 1.3f,0);
		}*/
		 if (Input.GetKey (KeyCode.A)) {
			transform.position -= Vector3.left * speed * Time.deltaTime;
			transform.forward=new Vector3(-dirX,0,0);
		} 
		else if (Input.GetKey (KeyCode.D)) 
		{
			transform.position -= Vector3.right * speed * Time.deltaTime;
			transform.forward=new Vector3(-dirX,0,0);
		}
		else if (Input.GetKey (KeyCode.S)) 
		{
			transform.position += Vector3.forward * speed * Time.deltaTime;
			transform.forward=new Vector3(0,0,0);
		}

		else if (Input.GetKey (KeyCode.W)) 
		{
			transform.position += Vector3.back * speed * Time.deltaTime;
			//transform.forward = new Vector3 (180,0,0);
			transform.eulerAngles=new Vector3(0,180,0);
		}

	}

	// On collision with the student

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Violator" && Input.GetKey (KeyCode.Space) ) 
		{
			MainGameScore.mainScore += 1;
			MainGameScore.score += 1;
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Student" && Input.GetKey (KeyCode.Space)) 
		{

			MainGameScore.life -= 1;
			Destroy (col.gameObject);
		}

	}

}
