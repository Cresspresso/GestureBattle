using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSwitcher : MonoBehaviour
{
	public PlayerWeapon[] weapons = new PlayerWeapon[0];
	[SerializeField]
	private int m_selectedIndex = 0;
	public int selectedIndex {
		get => m_selectedIndex;
		set
		{
			var L = weapons.Length;
			if (L == 0)
			{
				m_selectedIndex = 0;
				return;
			}
			// wrap index to range [0, L)
			var x = value % L;
			x = x < 0 ? L + x : x;
			if (m_selectedIndex != x)
			{
				// disable old weapon
				selectedWeapon.enabled = false;
				// enable new weapon
				m_selectedIndex = x;
				selectedWeapon.enabled = true;
			}
		}
	}
	public PlayerWeapon selectedWeapon => weapons[selectedIndex];

	private void Start()
	{
		foreach (var weapon in weapons)
		{
			weapon.Prepare();
		}
		selectedWeapon.enabled = true;
		Debug.Log("enabled selected");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedIndex = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			selectedIndex = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			selectedIndex = 2;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			selectedIndex = 3;
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			++selectedIndex;
		}

		// shoot button
		if (Input.GetButtonDown("Fire1"))
		{
			selectedWeapon.reload.timeSinceLastButtonPress = 0.0f;
		}
	}
}
