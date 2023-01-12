using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : RobotGuardFSM
{
    private Vector4 targetLastPositionAndTime;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        UpdateTargetLastPositionAndTime();
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 targetLastPosition = new Vector3(targetLastPositionAndTime.x, targetLastPositionAndTime.y, targetLastPositionAndTime.z);
        float lastTime = targetLastPositionAndTime.w;
        steeringBehaviours.Pursue(targetLastPosition.magnitude / lastTime);

        UpdateTargetLastPositionAndTime();
    }

    void UpdateTargetLastPositionAndTime()
    {
        Transform olakase = robotguardaicontroller.player;
        Transform olakase2 = olakase.transform;
        Vector3 targetPosition = robotguardaicontroller.player.transform.position;
        targetLastPositionAndTime = new Vector4(targetPosition.x, targetPosition.y, targetPosition.z, Time.time);
    }
}
