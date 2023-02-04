using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : StateMachineBehaviour
{
    public Transform PPos;
    public Vector3 Target;
    public Vector3 AboveTarget;
    public Vector3 ProjeSpawn;
    public Vector3 NewProje;
    public GameObject balls;
    Rigidbody2D rb;
    Rigidbody2D ballsbody;
    
    int i;
    int flag;
    float timerino;
    float firsttime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        i = 1;
       PPos = GameObject.FindGameObjectWithTag("Pyer").transform;
       rb = animator.GetComponent<Rigidbody2D>();
       Target = new Vector3(PPos.position.x,-1,0);
       AboveTarget = new Vector3(PPos.position.x,5,0);
       ProjeSpawn = new Vector3(rb.position.x + 6,5,0);
       flag = 0;
       firsttime = 1.75f;
       timerino = firsttime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timerino -= Time.deltaTime;
       if(i <= 4 && timerino <= 0)
       {
        NewProje = new Vector3(0, i,0);
        GameObject proj = Instantiate(balls, ProjeSpawn, Quaternion.identity);
        ProjeSpawn += NewProje;
        i++;
        timerino = firsttime;
       }
       if (i > 4)
       {
        flag = 1;
       }

       if(flag == 1)
       {
        animator.SetTrigger("Back to it");
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Back to it");
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
