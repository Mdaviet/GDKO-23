using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 4f;
    float horizontalMovement;
    Rigidbody2D rB;

    [Header("Jumping")]
    [SerializeField] float jumpForce = 3f;
    bool justJumped = false;

    [Header("Ground")]
    [SerializeField] bool onGround = false;
    [SerializeField] Collider2D floorCollider;
    [SerializeField] ContactFilter2D floorFilter;

    SpriteRenderer playerSprite;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        onGround = floorCollider.IsTouching(floorFilter);

        if (justJumped == false && Input.GetButton("Jump") && onGround == true) justJumped = true;

        // if (horizontalMovement < 0) gameObject.GetComponent<SpriteRenderer>().flipX = false;
        // if (horizontalMovement > 0) gameObject.GetComponent<SpriteRenderer>().flipX = true;

        if (horizontalMovement < 0) playerSprite.flipX = false;
        if (horizontalMovement > 0) playerSprite.flipX = true;

    }

    private void FixedUpdate() 
    {
        rB.velocity = new Vector2(horizontalMovement * speed, rB.velocity.y);

        if (justJumped == true)
        {
            justJumped = false;
            rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
