using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimWeaponShoot : StateMachineBehaviour
{
    private bool hasShot;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasShot = false;
        Debug.Log("shoot enter");
    }

    public float shootAtNormalizedTime = 0.1f;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (hasShot) { return; }

        Debug.Log("shoot update");

        if (stateInfo.normalizedTime >= shootAtNormalizedTime)
        {
            Debug.Log("shoot now");
            hasShot = true;
            animator.GetComponentInParent<PlayerWeapon>().Discharge();
        }
    }
}
