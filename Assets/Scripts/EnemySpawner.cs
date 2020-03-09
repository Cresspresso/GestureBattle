using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	private List<SpawnPoint> spawns = new List<SpawnPoint>();

	private void Update()
	{
		if (FindObjectsOfType<EnemyHealth>().Length == 0)
		{
			SpawnAll(enemyPrefab);
		}
	}

	public void SpawnRandom(GameObject prefab)
	{
		var i = Random.Range(0, spawns.Count);
		var spawnPoint = spawns[i];
		spawnPoint.Spawn(prefab);
	}

	public void SpawnAll(GameObject prefab)
	{
		foreach (var spawnPoint in spawns)
		{
			spawnPoint.Spawn(prefab);
		}
	}

	public void AddSpawnPoint(SpawnPoint p)
	{
		spawns.Add(p);
	}

	public void RemoveSpawnPoint(SpawnPoint p)
	{
		spawns.Remove(p);
	}
}
