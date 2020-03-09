using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages which weapon is currently equipped.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class PlayerWeaponSwitcher : MonoBehaviour
{
	public PlayerWeapon[] weapons;

	[SerializeField]
	private int m_equippedIndex = 0;

	public int equippedIndex {
		get => m_equippedIndex;
		set
		{
			var i = WrapIndex(value);
			if (m_equippedIndex != i)
			{
				m_equippedIndex = i;
				OnEquippedImpl();
			}
		}
	}

	private int WrapIndex(int i)
	{
		var L = weapons.Length;
		if (L == 0) { Debug.LogError("weapons array is empty", this); }
		i = i % L;
		i = i < 0 ? L + i : i;
		return i;
	}

	private void OnEquippedImpl()
	{
		for (int i = 0; i < weapons.Length; i++)
		{
			weapons[i].gameObject.SetActive(i == equippedIndex);
		}
	}

	private void Start()
	{
		m_equippedIndex = WrapIndex(m_equippedIndex);
		OnEquippedImpl();
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			++equippedIndex; // with wrap
			Debug.Log("Equipped: " + equippedIndex, this);
		}
	}
}
