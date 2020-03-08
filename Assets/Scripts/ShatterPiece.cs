using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A not-yet-shattered piece of a <see cref="ShatterGroup"/> which can be shattered.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class ShatterPiece : MonoBehaviour
{
	private Rigidbody m_rb;
	public Rigidbody rb {
		get
		{
			if (!m_rb) { m_rb = GetComponent<Rigidbody>(); }
			return m_rb;
		}
	}

	private PushByBullet m_pb;
	public PushByBullet pb {
		get
		{
			if (!m_pb) { m_pb = GetComponent<PushByBullet>(); }
			return m_pb;
		}
	}

	private void Start()
	{
		if (pb)
		{
			pb.enabled = false;
		}
	}

	/// <summary>
	/// Called by <see cref="ShatterGroup"/>.
	/// </summary>
	/// <author>Elijah Shadbolt</author>
	public void OnShatter(float explosionForce, Vector3 explosionCentre, float explosionRadius, float upwardsModifier)
	{
		try
		{
			transform.SetParent(null);

			rb.isKinematic = false;
			rb.AddExplosionForce(explosionForce, explosionCentre, explosionRadius, upwardsModifier, ForceMode.Impulse);

			if (pb)
			{
				pb.enabled = true;
			}
		}
		finally
		{
			Destroy(this);
		}
	}

	/// <summary>
	/// Invoked by <see cref="ProjectileBullet"/>.
	/// </summary>
	/// <author>Elijah Shadbolt</author>
	void OnBulletCollision(BulletCollision collision)
	{
		if (!enabled) { return; }

		var group = GetComponentInParent<ShatterGroup>();
		if (group)
		{
			group.Shatter(collision.point);
		}
	}
}
