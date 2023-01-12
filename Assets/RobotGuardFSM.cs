using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGuardFSM : StateMachineBehaviour
{
    // Start is called before the first frame update
    protected RobotGuardAIController robotguardaicontroller;
    protected SteeringBehaviours steeringBehaviours;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject gameObject = animator.gameObject;
        robotguardaicontroller = gameObject.GetComponent<RobotGuardAIController>();
        steeringBehaviours = gameObject.GetComponent<SteeringBehaviours>();
        steeringBehaviours.SetTarget(robotguardaicontroller.player);
    }
}
