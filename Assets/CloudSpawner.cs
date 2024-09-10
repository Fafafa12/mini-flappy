using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
	public GameObject cloudPrefab;
	public float spawnTime = 0.5f;
	public float heightOffset = 11f;

	private float timer = 0f;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (timer < spawnTime)
			timer += Time.deltaTime;
		else
		{
			SpawnCloud();
			timer = 0;
		}
	}

	void SpawnCloud()
	{
		float lowestY = transform.position.y - heightOffset;
		float highestY = transform.position.y + heightOffset;

		Instantiate(cloudPrefab, new Vector3(transform.position.x, Random.Range(lowestY, highestY), 0), transform.rotation);
	}
}
