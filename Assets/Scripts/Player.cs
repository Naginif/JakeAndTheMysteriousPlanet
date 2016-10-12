using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public static Player instance;

    public float jumpForce = 6f;
    public float runningSpeed = 1.5f;
    public LayerMask groundLayer;
    public LayerMask BoxLayer;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector3 startingPosition;

    // Use this for initialization
    public void StartGame ()
    {
        animator.SetBool("isAlive", true);
        startingPosition = new Vector3(-5.73f, -1.4f, 0);
	}

    public void Kill()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);

        if (PlayerPrefs.GetFloat("highscore", 0) < this.GetDistance())
            PlayerPrefs.SetFloat("highscore", this.GetDistance());
    }

    public float GetDistance()
    {
        float travelDistance = Vector2.Distance(new Vector2(startingPosition.x, 0), new Vector2(this.transform.position.x, 0));
        return travelDistance;
    }
    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
       // startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0))
                Jump();
            if (Input.GetMouseButtonDown(1))
                SuperJump();
        }


        animator.SetBool("isGrounded", IsGrounded());
	}

    void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (!IsObstacle())
            {
                if (rb.velocity.x < runningSpeed)
                    rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
            }
        }
    }

    void Jump()
    {
        if(IsGrounded())
             rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void SuperJump()
    {
        if (IsGrounded())
            rb.AddForce(Vector2.up * jumpForce * 1.5f, ForceMode2D.Impulse);
    }

    
    bool IsGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, .2f, groundLayer.value))
            return true;
        else if (Physics2D.Raycast(this.transform.position, Vector2.down, .2f, BoxLayer.value))
            return true;
        else
            return false;
    }

    bool IsObstacle()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.right, 1f, BoxLayer.value))
            return true;
        else
            return false;
    }
}
