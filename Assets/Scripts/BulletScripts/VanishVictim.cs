using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishVictim : MonoBehaviour
{
	public GameObject root;

	void OnBulletCollision(BulletCollision collision)
	{
		if (collision.bullet.TryGetComponent(out VanishBullet vanish))
		{
			if (!root) { root = gameObject; }

			Destroy(root);
		}
	}
}
