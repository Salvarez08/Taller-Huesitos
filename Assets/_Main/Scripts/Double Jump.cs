using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    private int jumpsRemaining;
    public bool isGrounded;

    void Start()
    {
        jumpsRemaining = maxJumps; // Initialize jumps
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Reset vertical velocity for a consistent second jump
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpsRemaining--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpsRemaining = maxJumps; // Reset jump count
        }
    }
}
