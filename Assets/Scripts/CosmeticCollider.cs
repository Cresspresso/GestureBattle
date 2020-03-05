using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NOT COMPLETED.
/// A physics object which is not an obstacle for player movement, but is affected by players walking over it.
/// Attach to a collider.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class CosmeticCollider : MonoBehaviour
{
	private Rigidbody m_rb;
	public Rigidbody rb {
		get
		{
			if (!m_rb) { m_rb = GetComponent<Rigidbody>(); }
			return m_rb;
		}
	}

	private Dictionary<Collider, int> touches = new Dictionary<Collider, int>();

	public bool autoPrepareTriggerColliders = true;

	//private void FixedUpdate()
	//{
	//	var rbt = new Dictionary<Rigidbody, int>();
	//	foreach (var touch in touches)
	//	{
	//		var collider = touch.Key;
	//		var num = touch.Value;
	//		collider.GetComponentInParent<Rigidbody>();
	//	}
	//}

	private void Start()
	{
		if (autoPrepareTriggerColliders)
		{
			foreach (var col in GetComponents<Collider>())
			{
				col.isTrigger = true;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (touches.ContainsKey(other))
		{
			touches[other] += 1;
		}
		else
		{
			touches.Add(other, 1);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (touches.ContainsKey(other))
		{
			touches[other] -= 1;
			if (touches[other] == 0)
			{
				touches.Remove(other);
			}
		}
	}
}
