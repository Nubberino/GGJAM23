using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandom : StateMachineBehaviour
{
    int randoe;
    float CDeez;
    int yee;
    public Ballsmove blals;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      CDeez = 1f;
       randoe = Random.Range(1, 10);
       animator.ResetTrigger("Shoot");
       animator.ResetTrigger("Stroke");
       animator.ResetTrigger("Back to it");
       Debug.Log(randoe);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      Debug.Log(9 - yee);
      CDeez -= Time.deltaTime;
      if(CDeez <= 0)
      {
       if(randoe % (9-yee) == 0)
       {
        yee = 1;
        animator.SetTrigger("Stroke");
        CDeez = 4;
       }
       else
       {
        yee += 1;
        animator.SetTrigger("Shoot");
        
        CDeez = 4;
       }
      }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}