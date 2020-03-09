using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for a delay (reloading) before letting the player fire again.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class PlayerWeapon : MonoBehaviour
{
	private PlayerShoot m_shoot;
	public PlayerShoot shoot { get { if (!m_shoot) { m_shoot = GetComponent<PlayerShoot>(); } return m_shoot; } }

	public Animator anim;

	public float reloadTime = 0.5f;
	private float remainingTime;

	public float maxButtonEarlyDelay = 0.1f;
	private float timeSinceLastButtonPress = 0.0f;

	private void Start()
	{
		remainingTime = reloadTime;
	}

	private void Update()
	{
		// update reloading timer
		if (remainingTime > 0.0f)
		{
			remainingTime -= Time.deltaTime;
		}

		// update button press early delay
		if (timeSinceLastButtonPress < maxButtonEarlyDelay)
		{
			timeSinceLastButtonPress += Time.unscaledDeltaTime;
		}

		// check button press
		if (Input.GetButtonDown("Fire1"))
		{
			timeSinceLastButtonPress = 0.0f;
		}

		// if reloaded and player has recently pressed fire button
		if (remainingTime <= 0.0f && timeSinceLastButtonPress < maxButtonEarlyDelay)
		{
			// shoot
			shoot.Discharge();
			if (anim) { anim.SetTrigger("shot"); }

			// begin reloading
			remainingTime = reloadTime;
			timeSinceLastButtonPress = maxButtonEarlyDelay;
		}
	}
}
