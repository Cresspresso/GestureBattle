using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <author>Elijah Shadbolt</author>
public class EnemyMelee : MonoBehaviour
{
	//public float damage = 10;
	//public float reloadTime = 0.5f;
	//private float reload = 0.0f;

	//private void Update()
	//{
	//	if (reload > 0.0f)
	//	{
	//		reload -= Time.deltaTime;
	//		if (reload < 0.0f)
	//		{
	//			reload = 0.0f;
	//		}
	//	}
	//}

	private void OnTriggerEnter(Collider other)
	{
		var player = other.GetComponentInParent<PlayerEntity>();
		if (player)
		{
			player.health.Kill();
			//if (reload <= 0.0f)
			//{
			//	reload = reloadTime;
			//}
		}
	}

	/// <summary>Custom Event</summary>
	/// <author>Elijah Shadbolt</author>
	void OnKilled()
	{
		Destroy(this);
	}
}
