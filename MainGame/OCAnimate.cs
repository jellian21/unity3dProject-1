using UnityEngine;
using System.Collections;

public class OCAnimate : MonoBehaviour {

	public GameObject character;
	public int speed;

	public Animator anim;
	public bool walk;
	public bool idle;
	Rigidbody rb;

	public AudioSource correctSource;
	public AudioSource wrongSource;

	public AudioClip correctClip;
	public AudioClip wrongClip;


	void Awake()
	{	
		anim = GetComponent<Animator>();
		Rigidbody rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//Vector3 dir=new Vector3();
		float dirX=Input.GetAxisRaw("Horizontal");
		float dirY=Input.GetAxisRaw("Vertical");

		/*if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (0, -1.3f,0);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (0, 1.3f,0);
		}*/
		if (Input.GetKey (KeyCode.A)||Input.GetKey (KeyCode.LeftArrow)) {
			transform.position -= Vector3.left * speed * Time.deltaTime;
			transform.forward=new Vector3(-dirX,0,0);
			walk = true;
			idle=false;

		} 
		else if (Input.GetKey (KeyCode.D)||Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.position -= Vector3.right * speed * Time.deltaTime;
			transform.forward=new Vector3(-dirX,0,0);
			walk = true;
			idle=false;
		}
		else if (Input.GetKey (KeyCode.S)||Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.position += Vector3.forward * speed * Time.deltaTime;
			transform.forward=new Vector3(0,0,0);
			walk = true;
			idle=false;
		}

		else if (Input.GetKey (KeyCode.W)||Input.GetKey (KeyCode.UpArrow)) 
		{
			transform.position += Vector3.back * speed * Time.deltaTime;
			//transform.forward = new Vector3 (180,0,0);
			transform.eulerAngles=new Vector3(0,180,0);
			walk = true;
			idle=false;
		}

		if (dirX == 0 && dirY == 0) {
			idle = true;
			walk = false;
		}
		else {
			idle = false;
			walk = true;
		}

		anim.SetBool ("idle", idle);
		anim.SetBool ("walk", walk);
	}



	// On collision with the student

	void OnTriggerStay(Collider col)
	{


		if (col.gameObject.tag == "Violator" && Input.GetKey (KeyCode.Space) ) 
		{
			correctSource.clip = correctClip;
			correctSource.Play();

			MainGameScore.mainScore += 1;
			MainGameScore.score += 1;
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Student" && Input.GetKey (KeyCode.Space)) 
		{
			wrongSource.clip = wrongClip;
			wrongSource.Play ();

			MainGameScore.life -= 1;
			Destroy (col.gameObject);
		}

	}

}
