using UnityEngine;
using System.Collections;

public class SpawnCar : MonoBehaviour {

	public Transform car;
	public Transform[] spawnPoint;
	public int tiMe=5;
	public int speed=10;

	void Start()
	{
		InvokeRepeating ("Spawn", tiMe,tiMe);

	}
	void Update()
	{
		transform.position += Vector3.back * speed * Time.deltaTime;
	}
	void Spawn ()
	{
		int spawnIndex = Random.Range (0,spawnPoint.Length);

		Instantiate (car, spawnPoint [spawnIndex].position, car.rotation);


	}
}
