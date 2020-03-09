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
	public float muzzleVelocity = 100.0f;

	public PlayerShoot owner { get; private set; }

	public LayerMask hitMask = ~0;

	public Vector3 velocity { get; private set; }
	public bool useGravity = false;

	public float mass = 0.01f;
	public float impulseMultiplier = 1.0f;

	private bool hasExploded = false;

	public float lifetime = 10;

	public DelayedDestroy explosionPrefab;
	public Transform trailToUnparent;



	public void OnSpawned(PlayerShoot owner)
	{
		this.owner = owner;
	}

	private void Start()
	{
		Destroy(gameObject, lifetime);
		velocity = transform.forward * muzzleVelocity;
	}

	/// <author>Elijah Shadbolt</author>
	private void FixedUpdate()
	{
		if (hasExploded)
		{
			return;
		}

		// simulate gravity
		if (useGravity)
		{
			velocity += Physics.gravity * Time.deltaTime;
		}

		// get values
		var delta = velocity * Time.deltaTime;
		transform.rotation = Quaternion.LookRotation(delta, Vector3.up);

		var previousPosition = transform.position;
		var nextPosition = previousPosition + delta;

		// raycast against all things
		var epsilon = 0.0001f;
		Ray ray = new Ray(previousPosition - delta.normalized * epsilon, delta);
		var hits = Physics.RaycastAll(ray, delta.magnitude + 2 * epsilon, hitMask, QueryTriggerInteraction.Ignore);

		// filter hits to get first valid hit
		/// <author>Elijah Shadbolt</author>
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

			// move bullet to hit point
			transform.position = hit.point;

			// when hit
			WhenHit(new BulletCollision(
				bullet: this,
				other: hit.collider,
				point: hit.point,
				normal: hit.normal,
				bulletVelocity: velocity
			));
		}
		else
		{
			// move bullet along its trajectory
			transform.position = nextPosition;
		}
	}

	/// <author>Elijah Shadbolt</author>
	private void WhenHit(BulletCollision collision)
	{
		hasExploded = true;
		try
		{
			// send a message to scripts attached to the collider that the bullet hit
			collision.other.SendMessage("OnBulletCollision", collision, SendMessageOptions.DontRequireReceiver);

			// instantiate bullet effects
			if (explosionPrefab)
			{
				Instantiate(explosionPrefab, collision.point, Quaternion.LookRotation(collision.normal));
			}
			if (trailToUnparent)
			{
				trailToUnparent.SetParent(null);
			}
		}
		finally
		{
			Destroy(gameObject);
		}
	}
}
