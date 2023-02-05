using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;
public class Mov : MonoBehaviour
   {
   public float ms;
    public float cms;
    public float JumpHeight;
    public Animator anim;
    public Transform FloorCheck;
    float mvmt;

    public LayerMask grounded;
    public float CheckRadius;
    public bool isGrounded;
    public bool CanMove;
    public bool isInvinc = false;
    private bool Dash = true;
    private bool isDashing;

    public float Dpower = 20f;
    public float Dtime = 0.3f;
    public float Dcooldown = 1f;  
    float dcool;


    public Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    public bool isJumping = false;

    [SerializeField] private TrailRenderer tr;
    

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        CanMove = true;
        cms = ms;
        dcool = 1f;
        Dcooldown = dcool;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Jumping",false);
        if (!isGrounded)
        {
            anim.SetBool("Jumping",true);
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk",true);
        }
        Dcooldown -= Time.deltaTime;
        if (Dcooldown <= 0)
        {
            Dash = true;
        }
        if(isDashing)
        {
            return;
        }
        if(CanMove)
        {
        Inputs();
        ms = cms;
        }
        else
        {
         ms = 0;
        }
        Animate();
        if (Input.GetKeyDown(KeyCode.LeftShift) && Dash)
        {
            Dcooldown = dcool;
            StartCoroutine(Dashe());
        }
        
        
    }
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        Speed();
        isGrounded = Physics2D.OverlapCircle(FloorCheck.position, CheckRadius, grounded);
    }
    private void Speed()
    {
        rb.velocity = new Vector2(moveDirection * ms, rb.velocity.y);
        if(!isGrounded)
        {
            rb.velocity = new Vector2(moveDirection * 0.5f * ms, rb.velocity.y);
        }
        
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
            Flippy();
        else if (moveDirection < 0 && facingRight)
            Flippy();
    }

    private void Inputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        anim.SetFloat("Sped",Mathf.Abs(moveDirection));
        if(Input.GetButtonDown("Jump") && isGrounded|| Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isJumping = true;
            anim.SetBool("Jumping",true);
            Jumpe();
        }
        

    }

    private void Jumpe()
    {
        rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
    }

    private void Flippy()
    {
        if (facingRight)
        {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
        }
        else
        {
        facingRight = true;
        transform.Rotate(0f,-180f,0f);
        }
    }

    private IEnumerator Dashe()
    {
        
        Dash = false;
        isDashing = true;

        float OGrav = rb.gravityScale;
        rb.gravityScale = 0.1f * rb.gravityScale;
        if(facingRight)
        {
        rb.velocity = new Vector2(transform.localScale.x * Dpower, 0f);
        }
        else
        {
        rb.velocity = new Vector2(-transform.localScale.x * Dpower, 0f);
        }
        
        tr.emitting = true;
        isInvinc = true;
        yield return new WaitForSeconds(Dtime);
        isInvinc = false;
        tr.emitting = false;

        rb.gravityScale = OGrav;
        isDashing = false;
        

    }

    private IEnumerator Invinc()
    {
        Debug.Log("no");
        isInvinc = true;
        yield return new WaitForSeconds(Dtime);
    }

    void startInvinc()
    {
        if(!isInvinc)
        {
            StartCoroutine(Invinc());
        }
    }
}


