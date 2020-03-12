using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Enemy that seeks the player.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class EnemyAgent : MonoBehaviour
{
	private NavMeshAgent m_agent;
	public NavMeshAgent agent { get { if (!m_agent) { m_agent = GetComponent<NavMeshAgent>(); } return m_agent; } }

	public RoboCopAnimator anim;

	public PlayerEntity target;

	public float dodgePlayerAimAngle = 30.0f;
	public float dodgeMultiplier = 0.5f;
	public float attackCloseRadius = 5.0f;

	private void Start()
	{
		if (!target) { target = FindObjectOfType<PlayerEntity>(); }
	}

	private void OnTriggerEnter(Collider other)
	{
		var player = other.GetComponentInParent<PlayerEntity>();
		if (player)
		{
			target = player;

			if (anim)
			{
				anim.SpeedCategory = 2;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		var player = other.GetComponentInParent<PlayerEntity>();
		if (player)
		{
			if (target == player)
			{
				target = null;

				if (anim)
				{
					anim.SpeedCategory = 0;
				}
			}
		}
	}

	/// <summary>Custom Event</summary>
	/// <author>Elijah Shadbolt</author>
	void OnKilled()
	{
		agent.enabled = false;
		Destroy(this);
	}

	private void Update()
	{
		if (target)
		{
			var targetPosition = target.moveCamera.transform.position;
			var destination = targetPosition;

			/// If player is aiming at me, dodge to the left or right.
			/// <author>Elijah Shadbolt</author>
			var targetForward = target.moveCamera.transform.forward;
			var relativePosVec = transform.position - targetPosition;
			var dist = relativePosVec.magnitude;
			if (dist > attackCloseRadius)
			{
				if (Vector3.Angle(relativePosVec, targetForward) < dodgePlayerAimAngle)
				{
					var leftOfPlayer = Vector3.Cross(targetForward, Vector3.up);
					var v = relativePosVec - targetForward;
					bool isLeft = Vector3.Dot(leftOfPlayer, v) > 0;
					var vec = leftOfPlayer.normalized * ((isLeft ? 1 : -1) * dodgeMultiplier * dist);
					destination = targetPosition + vec;
				}
			}

			agent.destination = destination;
		}
		else
		{
			agent.destination = transform.position;

		}
	}
}
