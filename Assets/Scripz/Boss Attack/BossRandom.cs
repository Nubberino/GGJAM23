using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandom : StateMachineBehaviour
{
    int randoe;
    float CDeez;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      CDeez = 1f;
       randoe = Random.Range(1, 10);
       animator.ResetTrigger("Shoot");
       animator.ResetTrigger("Stroke");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      CDeez -= Time.deltaTime;
      if(CDeez <= 0)
      {
       if(randoe % 2 == 0)
       {
        animator.SetTrigger("Shoot");
       }
       else
       {
         animator.SetTrigger("Stroke");
       }
      }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}