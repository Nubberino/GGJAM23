using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballsmove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 Target;
    public Transform PPos;
    public GameObject blals;
    public GameObject Boss;
    public int y;
    void Start()
    {
        Invoke("DestroyProjectile", 2f);
     PPos = GameObject.FindGameObjectWithTag("Pyer").transform;
     rb = blals.GetComponent<Rigidbody2D>();

     Boss = GameObject.FindGameObjectWithTag("Kreator");

     Physics2D.IgnoreCollision(Boss.GetComponent<Collider2D>(), GetComponent<Collider2D>());
     Target = new Vector3(PPos.position.x, -2.66f, 0);

    }
    // Update is called once per frame
    void Update()
    {
     

     Vector2 newPos = Vector2.MoveTowards(rb.position, Target, 9 * Time.fixedDeltaTime);
       rb.MovePosition(newPos);
     

     
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        // PlayerHP hp = other.GetComponent<PlayerHP>();
        if(other.CompareTag("Pyer") /*&& put health here*/)
        {
        DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
