using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private animCharacter animChar;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForse;
    [SerializeField] public bool isGrounded = false;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Animator animatorRotate;
    public bool rotateCharacter = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animChar = GetComponent<animCharacter>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
            Jump();

        if (Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animatorRotate.SetBool("rotate", false);
                rotateCharacter = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                animatorRotate.SetBool("rotate", true);
                rotateCharacter = false;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                animatorRotate.SetBool("rotate", false);
                rotateCharacter = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                animatorRotate.SetBool("rotate", true);
                rotateCharacter = false;
            }
        }

        else animChar.onClickIdle();
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForse);
            animChar.onClickJump();
        }   
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction) * speed, rb.velocity.y);
        animChar.onClickRun();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "step")
        {
            this.transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "step")
        {
            this.transform.parent = null;
        }
    }
}
