using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
	public Transform target;

	private void Start()
	{
		if (!target) { target = FindObjectOfType<PlayerMovement>().transform; }
	}

	private void Update()
	{
		GetComponent<NavMeshAgent>().destination = target.position;
	}
}
