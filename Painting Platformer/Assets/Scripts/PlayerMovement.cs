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

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        onGround = floorCollider.IsTouching(floorFilter);

        if (justJumped == false && Input.GetButton("Jump") && onGround == true)
            justJumped = true;
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
