﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <author>Elijah Shadbolt</author>
public class ShatterGroup : MonoBehaviour
{
	private ShatterPiece[] pieces;
	public float explosionForce = 100.0f;
	public float explosionRadius = 4.0f;
	public float upwardsModifier = 1.0f;

	/// <author>Elijah Shadbolt</author>
	private void Awake()
	{
		pieces = GetComponentsInChildren<ShatterPiece>();

		foreach (var piece in pieces)
		{
			piece.rb.isKinematic = true;
		}
	}

	/// <author>Elijah Shadbolt</author>
	public void Shatter(Vector3 explosionCentre)
	{
		try
		{
			foreach (var piece in pieces)
			{
				piece.OnShatter(explosionForce, explosionCentre, explosionRadius, upwardsModifier);
			}
		}
		finally
		{
			Destroy(this);
		}
	}

	/// <author>Elijah Shadbolt</author>
	public void ShatterFromHere() => Shatter(transform.position);
}
