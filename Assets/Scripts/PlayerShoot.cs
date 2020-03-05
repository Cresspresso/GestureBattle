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

	public Animator armAnimator;

	private bool isShooting = false;
	private float timeToIdle2 = 20.0f;
	private float counter = 0.0f;

	public void Discharge()
	{
		counter = 0.0f;
		isShooting = true;
		armAnimator.SetTrigger("shot");

		var bullet = Instantiate(bulletPrefab, spawnLocation.position, spawnLocation.rotation);
		bullet.owner = this;
		bullet.GetComponent<Rigidbody>().velocity = spawnLocation.forward * muzzleVelocity;

		isShooting = false;
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Discharge();
		}

		counter += Time.deltaTime;
		Debug.Log(counter);

		if (counter >= timeToIdle2 && isShooting == false)
		{
			armAnimator.SetTrigger("toIdle2");
			counter = 0.0f;
		}
	}
}
