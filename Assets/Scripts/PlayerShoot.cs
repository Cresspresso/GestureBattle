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
	public Animator armAnimator;

	private bool isShooting = false;
	private float timeToIdle2 = 20.0f;
	private float counter = 0.0f;

	public ProjectileBullet Discharge()
	{
		/// <author>Lorenzo</author>
		counter = 0.0f;
		isShooting = true;
		armAnimator.SetTrigger("shot");

		/// <author>Elijah Shadbolt</author>
		var bullet = Instantiate(bulletPrefab, spawnLocation.position, spawnLocation.rotation);
		bullet.OnSpawned(this);

		/// <author>Lorenzo</author>
		isShooting = false;

		return bullet;
	}

	private void Update()
	{
 		/// <author>Lorenzo</author>
		counter += Time.deltaTime;

		if (counter >= timeToIdle2 && isShooting == false)
		{
			armAnimator.SetTrigger("toIdle2");
			counter = 0.0f;
		}
	}
}
