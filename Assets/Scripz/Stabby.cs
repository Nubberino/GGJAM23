using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabby : MonoBehaviour
{
    public float chargetime;
    public float chargecurr;
    public Mov movs;
    public float stabCD;
    public GameObject stab;
    public Animator anim;
    void Start()
    {
        chargecurr = chargetime;
        stab.GetComponent<BoxCollider2D>().enabled = false;

    }

    void Update()
    {

        stabCD -= Time.deltaTime;
        if (stabCD <= 0)
        {
            if(Input.GetKey(KeyCode.Mouse1))
            {
                anim.SetBool("Charging",true);
                chargecurr -= Time.deltaTime;
                movs.CanMove = false;
                stab.GetComponent<BoxCollider2D>().enabled = true;
                
                if(Input.GetKeyDown(KeyCode.Mouse0) && chargecurr <= 0)
                {
                    England();
                }
            
                
            }
            if(Input.GetKeyUp(KeyCode.Mouse1))
            {
            chargecurr = chargetime;
            anim.SetBool("Charging", false);
            movs.CanMove = true;
            }
            
        }
    }

    public void England()
    {
        stabCD = 2;
        chargecurr = chargetime;
        stab.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("SwingWep",true);
        Invoke("Unfreeze", 0.11f);
    }

    void Unfreeze()
    {
        movs.CanMove = true;
        anim.SetBool("SwingWep",false);
        anim.SetBool("Charging",false);
    }
}
