using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	private PlayerShoot m_shoot;
	public PlayerShoot shoot { get { if (!m_shoot) { m_shoot = GetComponentInChildren<PlayerShoot>(); } return m_shoot; } }

	private PlayerReload m_reload;
	public PlayerReload reload { get { if (!m_reload) { m_reload = GetComponentInChildren<PlayerReload>(); } return m_reload; } }

	private void OnEnable()
	{
		reload.enabled = true;
	}

	private void OnDisable()
	{
		reload.enabled = false;
	}

	public void Prepare()
	{
		reload.Prepare();
	}
}
