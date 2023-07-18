using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputVertical;
    public float speed;
    private float moveInput;
    public static bool facingRight = true;
    public Animator animator;
    public float timeBtwAttack;
    private float cooldown = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        
        inputVertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            flip();
        }
        
        if (cooldown <= 0 && Input.GetKey(KeyCode.Space))
        {
            cooldown = timeBtwAttack;
            animator.SetBool("IsAttacking", true);
            
        } else
        {
            animator.SetBool("IsAttacking", false);
            cooldown -= Time.deltaTime;
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Update()
    {

    }
}
