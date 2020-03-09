using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for shooting projectiles from a player character.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class PlayerShoot : MonoBehaviour
{
	private PlayerEntity m_player;
	public PlayerEntity player { get { if (!m_player) { m_player = GetComponentInParent<PlayerEntity>(); } return m_player; } }

	public ProjectileBullet bulletPrefab;
	public Transform spawnLocation;

	public ProjectileBullet Discharge()
	{
		/// <author>Elijah Shadbolt</author>
		var bullet = Instantiate(bulletPrefab, spawnLocation.position, spawnLocation.rotation);
		bullet.OnSpawned(this);

		return bullet;
	}
}
