using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float climbSpeed = 3f;
    public float jumpForce = 600f;

    public bool isGrounded;
    public bool isJumping;
    [HideInInspector]
    public bool isClimbing = false;


    public SpriteRenderer spriteRenderer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Animator animator;

    public CapsuleCollider2D playerCollider;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;

    public static PlayerMovement instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning($"Destruction de l'objet en trop : {gameObject.name}");
            Destroy(gameObject); // Supprime cette instance en trop
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed /*Time.fixedDeltaTime*/;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed /*Time.fixedDeltaTime*/;

        if (Input.GetButtonDown("Jump") && isGrounded &&!isClimbing)
        {
            isJumping = true;
        }

        Flip(rb.linearVelocityX);

        float characterVelocity = Mathf.Abs(rb.linearVelocityX);
        animator.SetFloat("speed", characterVelocity);
        animator.SetBool("isClimbing", isClimbing);
    }

    void FixedUpdate()
    {
        //si le radius touche des elements qui ont le layer default, isGrounded est true, player et ladder sont en couche player -> false
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (!isClimbing)
        {

            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocityY);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);

            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else
        {
            //déplacement verticale(echelle)
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }
}
