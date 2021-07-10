using UnityEngine;
using System.Collections;

public class StudentSpawn : MonoBehaviour {

	public Transform violator;
	public Transform[] spawnPoints;
	//public float tiMe=2;

	void Update()
	{
		//InvokeRepeating ("Spawn", tiMe, tiMe);
		Spawn ();

	}

	void Spawn ()
	{
		int spawnIndex = Random.Range (0,spawnPoints.Length);
//		int violatorCount = GameObject.FindGameObjectsWithTag ("Violator").Length;

		GameObject[] npc = GameObject.FindGameObjectsWithTag ("Violator");
		int number = npc.Length;

		if (number< 3) 
		{
			Instantiate (violator, spawnPoints [spawnIndex].position, spawnPoints [spawnIndex].rotation);
		}

	}
}
