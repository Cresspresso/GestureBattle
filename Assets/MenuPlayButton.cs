using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPlayButton : MonoBehaviour
{
	public float secondsToPlay = 1.0f;
	public Animator anim;

	private void Awake()
	{
		var b = GetComponent<Button>();
		b.onClick.RemoveListener(OnClick);
		b.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
		if (MenuQuitButton.isSceneChanging) { return; }
		MenuQuitButton.isSceneChanging = true;
		try
		{
			anim.SetTrigger("Play");
		}
		finally
		{
			StartCoroutine(PlayCoroutine());
		}
	}

	IEnumerator PlayCoroutine()
	{
		yield return new WaitForSeconds(secondsToPlay);
		SceneManager.LoadScene(1);
	}
}
