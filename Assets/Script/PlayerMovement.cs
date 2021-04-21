using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    private bool isJumping = false;
    public bool isGrounded = false;

    [HideInInspector]
    public bool isClimbing = false;
    public float jumpForce;
    public Rigidbody2D rb;


    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    
    public Transform groundCheck;
    public float  groundCheckRadius;
    public LayerMask collisionLayers;

    public SpriteRenderer spriteRenderer;

    public CapsuleCollider2D playerCollider;

    
    private float horizontalMovement;
    private float verticalMovement;

     public static PlayerMovement instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }
        instance = this;
    
    }

    


    void Update(){

        
        
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded == true && !isClimbing){
                isJumping = true;
        }
 


        
        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed",characterVelocity);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if(!isClimbing){
        
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping){
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping=false;
        }
        }else
        {
            //deplacement vertical
        Vector3 targetVelocity = new Vector2(0,_verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            
        }
       

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        MovePlayer(horizontalMovement,verticalMovement);
    }

    void Flip(float _velocity){

            if(_velocity > 0.1f){
                spriteRenderer.flipX = false;
            } else if (_velocity < -0.1f){
                spriteRenderer.flipX = true;

            }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
