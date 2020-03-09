using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Event arguments for custom event message "OnBulletCollision".
/// The event message is sent when the bullet has collided with another collider.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class BulletCollision
{
	public readonly ProjectileBullet bullet;
	public readonly Collider other;
	public readonly Vector3 point;
	public readonly Vector3 normal;
	public readonly Vector3 bulletVelocity;

	public BulletCollision(ProjectileBullet bullet, Collider other, Vector3 point, Vector3 normal, Vector3 bulletVelocity)
	{
		this.bullet = bullet;
		this.other = other;
		this.point = point;
		this.normal = normal;
		this.bulletVelocity = bulletVelocity;
	}
}

/// <summary>
/// Projectile with travel time, optionally affected by gravity.
/// </summary>
/// <author>Elijah Shadbolt</author>
public class ProjectileBullet : MonoBehaviour
{
	private Rigidbody m_rb;
	public Rigidbody rb {
		get
		{
			if (!m_rb) { m_rb = GetComponent<Rigidbody>(); }
			return m_rb;
		}
	}

	public float muzzleVelocity = 100.0f;

	public PlayerShoot owner { get; private set; }

	public Explosion explosionPrefab;
	public LayerMask hitMask = ~0;

	private Vector3 lastPosition;
	private bool hasExploded = false;

	public float lifetime = 10;


	public void OnSpawned(PlayerShoot owner)
	{
		this.owner = owner;
	}

	private void Start()
	{
		Destroy(gameObject, lifetime);
		lastPosition = rb.position;
		rb.velocity = transform.forward * muzzleVelocity;
	}

	/// <author>Elijah Shadbolt</author>
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

			bool noOwner = !owner;
			var validHits =
				from hit in hits
				orderby hit.distance
				let bullet = hit.collider.GetComponentInParent<ProjectileBullet>()
				where bullet != this // or bullet is null
				let player = hit.collider.GetComponentInParent<PlayerEntity>()
				where noOwner || player != owner.player // or player is null
				select hit;

			if (validHits.Any())
			{
				RaycastHit hit = validHits.First();
				WhenHit(new BulletCollision(
					bullet: this,
					other: hit.collider,
					point: hit.point,
					normal: hit.normal,
					bulletVelocity: rb.velocity
				));
			}
		}
		finally
		{
			lastPosition = newPosition;
		}
	}

	/// <author>Elijah Shadbolt</author>
	private void WhenHit(BulletCollision collision)
	{
		hasExploded = true;
		try
		{
			Instantiate(explosionPrefab, collision.point, Quaternion.LookRotation(collision.normal));
			collision.other.SendMessage("OnBulletCollision", collision, SendMessageOptions.DontRequireReceiver);
		}
		finally
		{
			Destroy(gameObject);
		}
	}
}
