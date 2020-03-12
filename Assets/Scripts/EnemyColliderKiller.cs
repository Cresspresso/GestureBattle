using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>Custom Event</summary>
/// <author>Elijah Shadbolt</author>
public class EnemyColliderKiller : MonoBehaviour
{
	private const bool findChildColliders = true;

	void OnKilled()
	{
		foreach (var c in GetComponentsInChildren<Collider>().Where(c => !c.isTrigger))
		{
			Destroy(c);
		}
	}
}
