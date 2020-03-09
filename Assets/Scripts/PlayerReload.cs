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
	public float timeSinceLastButtonPress { get; set; } = 0.0f;

	private void Start()
	{
		timeSinceLastButtonPress = maxButtonEarlyDelay;
		remainingTime = 0.0f;
		Debug.Log("start");
	}

	private void OnDisable()
	{
		timeSinceLastButtonPress = maxButtonEarlyDelay;
	}

	public void Prepare()
	{
		timeSinceLastButtonPress = maxButtonEarlyDelay;
		enabled = false;
		Debug.Log("disabled reload " + name);
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
