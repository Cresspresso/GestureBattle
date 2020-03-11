using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuQuitButton : MonoBehaviour
{
	private void Awake()
	{
		var b = GetComponent<Button>();
		b.onClick.RemoveListener(OnClick);
		b.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
		Quitter.Quit();
	}
}
