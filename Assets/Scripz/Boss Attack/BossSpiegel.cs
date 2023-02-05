using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiegel : StateMachineBehaviour
{
    public Vector3 Target;
    public Vector3 AboveTarget;
    public Vector3 ProjeSpawn;
    public Vector3 NewProje;
    public GameObject Spike;
    Rigidbody2D rb;
    Rigidbody2D SpikeBody;
    GameObject proj;
    public SpikeMove spikemove;

    int i = 3;
    float timerino;
    float firsttime;

    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     animator.ResetTrigger("Stroke");  
     animator.ResetTrigger("Back to it"); 
     rb = animator.GetComponent<Rigidbody2D>();
     ProjeSpawn = new Vector3(rb.position.x + 4.33f, -3.11f,-0.1f);
     
      firsttime = 1.75f;
      timerino = firsttime;
      i = 3;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timerino -= Time.deltaTime;
        
       if(i != 4 && timerino <= 0)
       {
        proj = Instantiate(Spike, ProjeSpawn, Quaternion.identity);
        i = 4;
        timerino = firsttime;
        
       }
       spikemove = proj.GetComponent<SpikeMove>();
       
       if(spikemove.flag == 2)
       {
       animator.SetTrigger("Back to it");
       Debug.Log("returning" + spikemove.flag);

       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Back to it");
        Debug.Log("Exit State");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
