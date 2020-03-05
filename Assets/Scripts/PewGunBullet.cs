using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Projectile with travel time, affected by gravity.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class PewGunBullet : MonoBehaviour
{
	private Rigidbody m_rb;
	public Rigidbody rb {
		get
		{
			if (!m_rb) { m_rb = GetComponent<Rigidbody>(); }
			return m_rb;
		}
	}

	public PlayerShoot owner;

	public Explosion explosionPrefab;
	public LayerMask hitMask = ~0;

	private Vector3 lastPosition;
	private bool hasExploded = false;

	public float lifetime = 10;



	private void Start()
	{
		lastPosition = rb.position;
		Destroy(gameObject, lifetime);
	}

	private void FixedUpdate()
	{
		if (hasExploded)
		{
			return;
		}

		var newPosition = rb.position;
		try
		{
			var delta = newPosition - lastPosition;
			Ray ray = new Ray(lastPosition, delta);
			var hits = Physics.RaycastAll(ray, delta.magnitude, hitMask, QueryTriggerInteraction.Ignore);

			var validHits =
				from hit in hits
				orderby hit.distance
				let bullet = hit.collider.GetComponentInParent<PewGunBullet>()
				where bullet != this // or bullet is null
				let player = hit.collider.GetComponentInParent<PlayerShoot>()
				where player != owner // or player is null
				select hit;

			if (validHits.Any())
			{
				RaycastHit hit = validHits.First();
				WhenHit(hit.point, hit.normal);
			}
		}
		finally
		{
			lastPosition = newPosition;
		}
	}

	private void WhenHit(Vector3 point, Vector3 normal)
	{
		hasExploded = true;
		try
		{
			Instantiate(explosionPrefab, point, Quaternion.LookRotation(normal));
		}
		finally
		{
			Destroy(gameObject);
		}
	}
}
