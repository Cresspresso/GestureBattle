using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
	//public RuntimeAnimatorController[] controllers = new RuntimeAnimatorController[0];
	public int i = 0;
	public GameObject[] arms;

	private void Start()
	{
		//GetComponent<Animator>().runtimeAnimatorController = controllers[0];
		arms[0].SetActive(true);
		arms[1].SetActive(false);
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			Debug.Log(i);
			//if (controllers.Length > 0)
			//{
			//	++i;
			//	while (i >= controllers.Length)
			//	{
			//		i -= controllers.Length;
			//	}
			//	GetComponent<Animator>().runtimeAnimatorController = controllers[i];
			//}

			//if (arms.Length > 0)
			//{
			//	//arms[i].SetActive(false);
			//	++i;
			//	while (i >= arms.Length)
			//	{
			//		i -= arms.Length;
			//	}
			//	//GetComponent<Animator>().runtimeAnimatorController = controllers[i];
			//	arms[i].SetActive(true);
			//}

			if (i == 0)
			{
				i++;
			}
			else if (i == 1)
			{
				i--;
			}

			if (i == 1)
			{
				arms[0].SetActive(false);
				arms[1].SetActive(true);
			}
			else if (i == 0)
			{
				arms[1].GetComponent<Animator>().SetTrigger("deactivate");
				StartCoroutine(waitToDisable(1.0f));
				//arms[0].SetActive(true);
				//arms[1].SetActive(false);
			}

			Debug.Log(i);
		}
	}

	IEnumerator waitToDisable(float _seconds)
	{
		yield return new WaitForSeconds(_seconds);

		if (i == 0)
		{
			arms[0].SetActive(true);
			arms[1].SetActive(false);
		}
	}
}
