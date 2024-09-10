using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
	public GameObject pipePrefab;
	public float spawnTime = 2f;
	public float heightOffset = 15f;
	private float timer = 0f;
	// Start is called before the first frame update
	void Start()
	{
		SpawnPipe();
	}

	// Update is called once per frame
	void Update()
	{
		if (timer < spawnTime)
			timer += Time.deltaTime;
		else
		{
			SpawnPipe();
			timer = 0;
		}
	}

	void SpawnPipe()
	{
		float lowestY = transform.position.y - heightOffset;
		float highestY = transform.position.y + heightOffset;

		Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestY, highestY), 0), transform.rotation);
	}
}
