using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private Rigidbody2D rb;

    public float jumpForce = 6f;
    public float runningSpeed = 1.5f;
    public LayerMask groundLayer;
    public Animator animator;
    // Use this for initialization

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start ()
    {

        //animator.SetBool("isAlive", true);

        for (int x = -9; x <= 9; x += 1)
        {
            Instantiate(Resources.Load("GroundMid"),
                        new Vector2(x, -4), 
                        Quaternion.identity);

        }
	}
	
    void FixedUpdate()
    {
        if (rb.velocity.x < runningSpeed)
            rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))        
            Jump();

        //animator.SetBool("isGrounded", IsGrounded());
	}

    void Jump()
    {
        if(IsGrounded())
             rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    
    bool IsGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1, groundLayer.value))
            return true;
        else
            return false;
    }
}
