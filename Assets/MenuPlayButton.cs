using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPlayButton : MonoBehaviour
{
	private void Awake()
	{
		var b = GetComponent<Button>();
		b.onClick.RemoveListener(OnClick);
		b.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
		SceneManager.LoadScene(1);
	}
}
