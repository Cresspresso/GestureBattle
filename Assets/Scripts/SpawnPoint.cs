using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	private void Awake()
	{
		var spawner = FindObjectOfType<EnemySpawner>();
		if (spawner)
		{
			spawner.AddSpawnPoint(this);
		}
	}

	private void OnDestroy()
	{
		var spawner = FindObjectOfType<EnemySpawner>();
		if (spawner)
		{
			spawner.RemoveSpawnPoint(this);
		}
	}

	public void Spawn(GameObject prefab)
	{
		Instantiate(prefab, transform.position, transform.rotation);
	}
}
