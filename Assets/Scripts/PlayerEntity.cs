using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Placed on the root of a player character, represents a unique player object.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class PlayerEntity : MonoBehaviour
{
	private MoveCamera m_moveCamera;
	public MoveCamera moveCamera { get { if (!m_moveCamera) { m_moveCamera = GetComponentInChildren<MoveCamera>(); } return m_moveCamera; } }

	private PlayerShoot m_shoot;
	public PlayerShoot shoot { get { if (!m_shoot) { m_shoot = GetComponentInChildren<PlayerShoot>(); } return m_shoot; } }

	private PlayerReload m_reload;
	public PlayerReload reload { get { if (!m_reload) { m_reload = GetComponentInChildren<PlayerReload>(); } return m_reload; } }

	private PlayerMovement m_movement;
	public PlayerMovement movement { get { if (!m_movement) { m_movement = GetComponentInChildren<PlayerMovement>(); } return m_movement; } }
}
