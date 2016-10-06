using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public static Player instance;

    public float jumpForce = 6f;
    public float runningSpeed = 1.5f;
    public LayerMask groundLayer;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector3 startingPosition;

    // Use this for initialization
    public void StartGame ()
    {
        animator.SetBool("isAlive", true);
        startingPosition = this.transform.position;

        for (int x = -9; x <= 4; x += 1)
        {
            Instantiate(Resources.Load("GroundMid"),
                        new Vector2(x, -2), 
                        Quaternion.identity);
        }
	}

    public void Kill()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);
    }

    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0))
                Jump();
        }

        animator.SetBool("isGrounded", IsGrounded());
	}

    void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (rb.velocity.x < runningSpeed)
                rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
        }
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
