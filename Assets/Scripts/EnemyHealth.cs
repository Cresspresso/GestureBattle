using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	void OnBulletCollision(BulletCollision collision)
	{
		if (collision.bullet.owner is PlayerShoot)
		{
			Destroy(gameObject);
		}
	}
}
