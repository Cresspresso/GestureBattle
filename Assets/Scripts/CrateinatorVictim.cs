using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attack to a Collider to make it become a crate when hit by a CrateinatorBullet.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class CrateinatorVictim : MonoBehaviour
{
	public Transform spawnTransformation;

	void OnBulletCollision(BulletCollision collision)
	{
		var inator = collision.bullet.GetComponent<CrateinatorBullet>();
		if (inator)
		{
			var go = Instantiate(inator.prefab, spawnTransformation.position, spawnTransformation.rotation);
			go.transform.localScale = spawnTransformation.localScale;

			Destroy(gameObject);
		}
	}
}
