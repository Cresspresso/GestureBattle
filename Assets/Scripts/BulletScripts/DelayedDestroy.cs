using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages a GameObject of temporary effects spawned by a bullet collision.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class DelayedDestroy : MonoBehaviour
{
	public float duration = 1.0f;

	private void Update()
	{
		duration -= Time.deltaTime;
		if (duration <= 0.0f)
		{
			Destroy(gameObject);
		}
	}
}
