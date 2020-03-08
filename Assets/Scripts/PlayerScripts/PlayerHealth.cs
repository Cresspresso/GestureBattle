using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public void Kill()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
