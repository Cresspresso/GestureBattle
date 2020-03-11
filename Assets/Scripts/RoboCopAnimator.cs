using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <author>Elijah Shadbolt</author>
public class RoboCopAnimator : MonoBehaviour
{
	[SerializeField]
	private Animator m_anim;
	public Animator anim { get { if (!m_anim) { m_anim = GetComponent<Animator>(); } return m_anim; } }

	public void TriggerKill()
	{
		if (anim) { anim.SetTrigger("Kill"); }
	}

	public int SpeedCategory {
		get => anim.GetInteger("SpeedCategory");
		set => anim.SetInteger("SpeedCategory", value);
	}

	/// <summary>Custom Event</summary>
	/// <author>Elijah Shadbolt</author>
	void OnKilled()
	{
		TriggerKill();
	}
}
