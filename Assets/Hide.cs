using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : RobotGuardFSM
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        steeringBehaviours.CleverHide();
    }
}
