using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An object which can be impacted and punched by a <see cref="ProjectileBullet"/>. Attach to a Collider.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class PushByBullet : MonoBehaviour
{
	private Rigidbody m_rb;
	public Rigidbody rb {
		get
		{
			if (!m_rb) { m_rb = GetComponentInParent<Rigidbody>(); }
			return m_rb;
		}
	}

	private bool doneOneFrame = false;

	public float bulletImpulseModifier = 1.0f;
	public float additionalImpulse = 0.0f;

	public bool useExplosionForce = false;
	public float upwardsModifier = 1.0f;



	private void Start()
	{
		// empty, just to show checkbox `enabled`
	}

	private void Update()
	{
		doneOneFrame = true;
	}

	private void OnEnable()
	{
		doneOneFrame = false;
	}

	/// <summary>
	/// Invoked by <see cref="ProjectileBullet"/>.
	/// </summary>
	/// <author>Elijah Shadbolt</author>
	void OnBulletCollision(BulletCollision collision)
	{
		if (!doneOneFrame) { return; }

		var impulse = collision.bulletVelocity * collision.bullet.mass * collision.bullet.impulseMultiplier;
		impulse *= bulletImpulseModifier;
		impulse += additionalImpulse * impulse.normalized;
		if (useExplosionForce)
		{
			// hit upwards for special effect
			impulse = (impulse.normalized + Vector3.up * upwardsModifier).normalized * impulse.magnitude;
		}
		rb.AddForceAtPosition(impulse, collision.point, ForceMode.Impulse);
	}
}
