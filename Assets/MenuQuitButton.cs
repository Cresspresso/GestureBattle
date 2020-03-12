using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuQuitButton : MonoBehaviour
{
	public static bool isSceneChanging { get; set; } = false;

	public float secondsToQuit = 1.0f;
	public Animator anim;

	private void Awake()
	{
		isSceneChanging = false;

		var b = GetComponent<Button>();
		b.onClick.RemoveListener(OnClick);
		b.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
		if (isSceneChanging) { return; }
		isSceneChanging = true;
		try
		{
			anim.SetTrigger("Quit");
		}
		finally
		{
			StartCoroutine(QuitCoroutine());
		}
	}

	IEnumerator QuitCoroutine()
	{
		yield return new WaitForSeconds(secondsToQuit);
		Quitter.Quit();
	}
}
