using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
	public RuntimeAnimatorController[] controllers = new RuntimeAnimatorController[0];
	private int i = 0;

	private void Update()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			if (controllers.Length > 0)
			{
				++i;
				while (i >= controllers.Length)
				{
					i -= controllers.Length;
				}
				GetComponent<Animator>().runtimeAnimatorController = controllers[i];
			}
		}
	}
}
