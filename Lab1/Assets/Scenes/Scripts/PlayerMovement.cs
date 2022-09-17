using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float jumpHeight = 5.0f;

    CircleCollider2D circleCollider;
    Rigidbody2D rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        //Body
        float hInput = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(hInput * movementSpeed * 100 * Time.deltaTime, rbody.velocity.y);
        Debug.Log(Time.deltaTime);
        rbody.velocity = movementVector;
    }
    void Update()
    {
        if (!circleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        return;
            
        if (Input.GetButtonDown("Jump"))
        {
            //Velocity
            //Vector2 jumpVector = new Vector2(0f,jumpHeight);
            //rbody.velocity += jumpVector;

            //Force
            rbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
}
