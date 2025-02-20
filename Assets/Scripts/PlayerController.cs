using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 2.0f;
    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    public float jumpForce = 3f;
    public LayerMask groundLayer;
    
    private float moveInput;
    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Jump()
    {
        
            // Застосування сили стрибка
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
    }
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundLayer);
        return hit.collider != null;
    }
}
