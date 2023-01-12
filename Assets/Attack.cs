using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : RobotGuardFSM
{
    private Shooter shooter;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        shooter = animator.gameObject.GetComponent<Shooter>();
        shooter.Init();
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shooter.TryFireTarget(robotguardaicontroller);
    }
}
