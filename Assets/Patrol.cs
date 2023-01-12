using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : RobotGuardFSM
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        steeringBehaviours.Wander();
    }
}
