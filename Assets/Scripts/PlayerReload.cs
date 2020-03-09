using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for a delay (reloading) before letting the player fire again.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class PlayerReload : MonoBehaviour
{
	private PlayerShoot m_playerShoot;
	public PlayerShoot playerShoot { get { if (!m_playerShoot) { m_playerShoot = GetComponent<PlayerShoot>(); } return m_playerShoot; } }

	public float reloadTime = 0.5f;
	private float remainingTime = 0.0f;

	public float maxButtonEarlyDelay = 0.1f;
	private float timeSinceLastButtonPress = 0.0f;

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
			playerShoot.Discharge();

			// begin reloading
			remainingTime = reloadTime;
			timeSinceLastButtonPress = maxButtonEarlyDelay;
		}
	}
}
