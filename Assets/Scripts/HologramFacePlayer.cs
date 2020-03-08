using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates to face the player if they are close, otherwise returns to normal.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class HologramFacePlayer : MonoBehaviour
{
	public PlayerEntity player;
	private Transform target;

	public float lerpTime = 0.3f;
	private float elapsedTime = 0.0f;

	void OnTriggerEnter(Collider other)
	{
		var op = other.GetComponentInParent<PlayerEntity>();
		if (op)
		{
			this.player = op;
			target = op.moveCamera.player;
		}
	}

	private void LateUpdate()
	{
		if (player)
		{
			elapsedTime += Time.deltaTime;
		}
		else
		{
			elapsedTime -= Time.deltaTime;
		}
		elapsedTime = Mathf.Clamp(elapsedTime, 0.0f, lerpTime);
		if (target)
		{
			transform.rotation = Quaternion.Lerp(
				transform.parent ? transform.parent.rotation : Quaternion.identity,
				Quaternion.LookRotation(target.position - transform.position),
				elapsedTime / lerpTime);
		}
		else
		{
			transform.localRotation = Quaternion.identity;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		var op = other.GetComponentInParent<PlayerEntity>();
		if (op == player)
		{
			this.player = null;
			// do not set target to null, because rotating back
		}
	}
}