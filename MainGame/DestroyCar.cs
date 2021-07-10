using UnityEngine;
using System.Collections;

public class DestroyCar : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Car") 
		{
			Destroy (col.gameObject);
		}

	}
}
