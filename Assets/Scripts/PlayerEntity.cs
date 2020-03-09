﻿using System.Collections;
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

	private PlayerWeaponSwitcher m_weaponSwitcher;
	public PlayerWeaponSwitcher weaponSwitcher { get { if (!m_weaponSwitcher) { m_weaponSwitcher = GetComponentInChildren<PlayerWeaponSwitcher>(); } return m_weaponSwitcher; } }

	private PlayerMovement m_movement;
	public PlayerMovement movement { get { if (!m_movement) { m_movement = GetComponentInChildren<PlayerMovement>(); } return m_movement; } }

	private PlayerHealth m_health;
	public PlayerHealth health { get { if (!m_health) { m_health = GetComponentInChildren<PlayerHealth>(); } return m_health; } }
}
