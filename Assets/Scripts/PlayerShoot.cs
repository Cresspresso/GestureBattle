using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for shooting projectiles from a player character.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class PlayerShoot : MonoBehaviour
{
	public PewGunBullet bulletPrefab;
	public Transform spawnLocation;
	public float muzzleVelocity = 100.0f;

	public void Discharge()
	{
		var bullet = Instantiate(bulletPrefab, spawnLocation.position, spawnLocation.rotation);
		bullet.owner = this;
		bullet.GetComponent<Rigidbody>().velocity = spawnLocation.forward * muzzleVelocity;
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Discharge();
		}
	}
}
