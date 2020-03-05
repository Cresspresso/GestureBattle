using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for shooting projectiles from a player character.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class PlayerShoot : MonoBehaviour
{
	public ProjectileBullet bulletPrefab;
	public Transform spawnLocation;

	/// <author>Elijah Shadbolt</author>
	public ProjectileBullet Discharge()
	{
		var bullet = Instantiate(bulletPrefab, spawnLocation.position, spawnLocation.rotation);
		bullet.OnSpawned(this);
		return bullet;
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Discharge();
		}
	}
}
