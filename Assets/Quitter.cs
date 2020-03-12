﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitter : MonoBehaviour
{
	public static void Quit()
	{
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}

#if !UNITY_EDITOR
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Quit();
		}
	}
#endif
}
