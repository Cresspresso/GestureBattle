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

	/// <author>Elijah Shadbolt</author>
	public ProjectileBullet Discharge()
	{
		counter = 0.0f;
		isShooting = true;
		armAnimator.SetTrigger("shot");

		var bullet = Instantiate(bulletPrefab, spawnLocation.position, spawnLocation.rotation);
		bullet.OnSpawned(this);


		isShooting = false; /// <author>Lorenzo</author>


		return bullet;
	}

	private void Update()
	{
		/// <author>Elijah</author>
		if (Input.GetButtonDown("Fire1"))
		{
			Discharge();
		}

 		/// <author>Lorenzo</author>
		counter += Time.deltaTime;
		Debug.Log(counter);

		if (counter >= timeToIdle2 && isShooting == false)
		{
			armAnimator.SetTrigger("toIdle2");
			counter = 0.0f;
		}
	}
}
