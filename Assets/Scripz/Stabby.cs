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
    void Start()
    {
        chargecurr = chargetime;
        stab.GetComponent<SpriteRenderer>().enabled = false;

    }

    void Update()
    {

        stabCD -= Time.deltaTime;
        if (stabCD <= 0)
        {
            if(Input.GetKey(KeyCode.Mouse1))
            {
                stab.GetComponent<SpriteRenderer>().enabled = true;
                chargecurr -= Time.deltaTime;
                if(Input.GetKeyDown(KeyCode.Mouse0) && chargecurr <= 0)
                {
                    England();
                    Debug.Log("Hi");
                }
                
            }
            if(Input.GetKeyUp(KeyCode.Mouse1))
            {
            chargecurr = chargetime;
            }
        }
    }

    public void England()
    {
        stabCD = 6;
        chargecurr = chargetime;
        stab.GetComponent<SpriteRenderer>().enabled = false;
    }
}
