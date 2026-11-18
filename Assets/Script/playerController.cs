using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField]private bool isJumping;

    [Header("Movement")]
    public float moveAcceleration = 10f;
    public float JumpForce = 20f;


    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isJumping= true;
        }
    }

    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        rb.linearVelocityX = moveAcceleration* movement.x;
        if(isJumping)
        {
            rb.AddForceY(JumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
