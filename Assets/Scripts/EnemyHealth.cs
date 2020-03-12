using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <author>Elijah Shadbolt</author>
public class EnemyHealth : MonoBehaviour
{
	public bool isDead { get; private set; } = false;

	void OnBulletCollision(BulletCollision collision)
	{
		if (collision.bullet.owner is PlayerShoot)
		{
			isDead = true;
			Destroy(gameObject, 5.0f);
			Destroy(this);
			BroadcastMessage("OnKilled", SendMessageOptions.DontRequireReceiver);
		}
	}
}
