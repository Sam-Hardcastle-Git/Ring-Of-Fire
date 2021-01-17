using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovement : MonoBehaviour
{
    public float Speed;
    private float Motion;
    public float JumpForce;

    public LayerMask groundLayers;

    public bool isGrounded = false;
    public bool objectOnLeft = false;
    public bool objectOnRight = false;

    public enum direction { left , right };
    public direction PCDirection;

    void FixedUpdate()
    {
        //if ringmode isn't active
        if (!GetComponent<PCRingOfFire>().RingMode)
        {
            //the character can move left and right
            MoveLeftAndRight();
        }

        //isGrounded becomes true when
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.2f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.2f, transform.position.y - 0.51f), groundLayers);

        //if the jump button is pressed and the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }        
    }    

    void Update()
    {
        CheckForBlockingObjects();
    }

    void MoveLeftAndRight()
    {
        //Set the value of the motion
        Motion = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        //Move the playable character
        transform.Translate(Motion, 0, 0);

        //reference to the direction indicator
        Transform directionIndicator = transform.GetChild(0);

        //if "left" is hit, set direction to left and alter the directionIndicator position
        if (Input.GetButton("left"))
        {
            PCDirection = direction.left;
            directionIndicator.position = new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z - 1f);
        }

        //if "right" is hit, set direction to left and alter the directionIndicator position
        else if (Input.GetButton("right"))
        {
            PCDirection = direction.right;
            directionIndicator.position = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z - 1f);
        }
    }

    void Jump()
    {
        switch(PCDirection)
        {
            //if the playable character is facing left and if there are no objects pushing from the right
            case direction.left:
                if (!objectOnRight)
                {
                    //jump
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce);
                }
            break;

            //if the playable character is facing right and if there are no objects pushing from the left
            case direction.right:
                if (!objectOnLeft)
                {
                    //jump
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce);
                }
            break;
        }        
    }

    void CheckForBlockingObjects()
    {
        switch(PCDirection)
        {
            //when facing left, objectOnRight is false and any objects on the left will be detected
            case direction.left:
            objectOnRight = false;
            objectOnLeft = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.49f), new Vector2(transform.position.x - 0.51f, transform.position.y + 0.49f), groundLayers);
            break;

            //when facing right, objectOnLeft is false and any objects on the right will be detected
            case direction.right:
            objectOnLeft = false;
            objectOnRight = Physics2D.OverlapArea(new Vector2(transform.position.x + 0.5f, transform.position.y - 0.49f), new Vector2(transform.position.x + 0.51f, transform.position.y + 0.49f), groundLayers);
            break;
        }
    }
}
