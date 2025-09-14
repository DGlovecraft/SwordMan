using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    public float speed = 5f;
    private GatherInput gatherInput;
    private Rigidbody2D rigidbody2D;
    private int direction = 1;
    private Animator animator;
    public float jumpForce;
    public float rayLength;
    public LayerMask groundLayer;
    public Transform Leftpoint;
    private bool grounded = false;

    void Start()
    {
        gatherInput = GetComponent<GatherInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetAnimatorValues();
    }

    private void FixedUpdate()
    {
        CheckStatus();
        Move();
        JumpPlayer();
    }

    private void JumpPlayer()
    {
        if (gatherInput.jumpInput && grounded)
        {
            // กระโดด
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);

            // สั่ง Animator เล่นอนิเมชัน Jump
            animator.SetTrigger("Jump");
        }
        gatherInput.jumpInput = false;
    }

    private void SetAnimatorValues()
    {
        animator.SetFloat("speed", Mathf.Abs(rigidbody2D.linearVelocity.x));
        animator.SetFloat("vSpeed", rigidbody2D.linearVelocity.y);
        animator.SetBool("Grounded", grounded);
    }

    void Move()
    {
        Flip();
        rigidbody2D.linearVelocity = new Vector2(speed * gatherInput.valueX, rigidbody2D.linearVelocity.y);
    }

    private void Flip()
    {
        if (gatherInput.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            direction *= -1;
        }
    }

    private void CheckStatus()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(Leftpoint.position, Vector2.down, rayLength, groundLayer);
        grounded = leftCheckHit.collider != null; 
    }
}
