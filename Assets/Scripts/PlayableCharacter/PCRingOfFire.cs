using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCRingOfFire : MonoBehaviour
{
    private float currentAngle;
    private float rotateRate = 850;
    private float flySpeed = 32;
    private float coolDown = 0.4f;

    private bool coolDownTriggered = false;
    public bool RingMode = false;
    
    public GameObject hitBox;
    public GameObject fireTrail;

    void Start ()
    {
        currentAngle = 0;
    }
	
    void Update ()
    {                
        //when the mouse is clicked, if the ringMode has cooled and nothing is directly blocking the character...
        if (Input.GetKeyDown(KeyCode.Mouse0) && coolDown == 0.4f && !GetComponent<PCMovement>().objectOnLeft && !GetComponent<PCMovement>().objectOnRight)
        {
            //activate ring mode
            RingMode = true;
        }
        
        if(RingMode)
        {
            Circle();
            FireTrail();
        } 
        
        if(coolDownTriggered)
        {
            CoolDown();
        }            
    }

    void Circle()
    {
        //cancel velocity
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        //set the rotation of the character
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));

        //disable gravity
        GetComponent<Rigidbody2D>().gravityScale = 0;

        #region rotate left or right depending on the current direction
        switch (GetComponent<PCMovement>().PCDirection)
        {
            case PCMovement.direction.right:
                currentAngle += Time.deltaTime * rotateRate;
                transform.Translate(Vector3.right * flySpeed * Time.deltaTime, Space.Self);
                break;

            case PCMovement.direction.left:
                currentAngle += Time.deltaTime * -rotateRate;
                transform.Translate(Vector3.left * flySpeed * Time.deltaTime, Space.Self);
                break;
        }
        #endregion rotate left or right depending on the current direction

        #region cancel Circle
        if (currentAngle >= 360f || currentAngle <= -360f)
        {
            RingMode = false;
            coolDownTriggered = true;            
            Cancel();
            SpawnHitBox();            
        }
        #endregion cancel Circle

        //cancel the ring of fire move when the mouse is pressed
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {           
            RingMode = false;
            coolDownTriggered = true;
            Cancel();
        }        
    }

    void SpawnHitBox()
    {
        //create a new hitbox if there isn't one already
        if (!GameObject.FindGameObjectWithTag("FireRing"))
        {
            GameObject newHitBox = Instantiate(hitBox, (transform.position + new Vector3(0f, 2f, 0f)), Quaternion.identity) as GameObject;
        }                                     
    }

    void Cancel()
    {
        //reset the characters orientation
        currentAngle = 0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        //re-enable gravity
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void FireTrail()
    {
        //set timer
        float timer = Time.deltaTime;

        //when timer runs out, reset timer and spawn a fire sprite
        if(Time.deltaTime >= timer)
        {
            GameObject fire = Instantiate(fireTrail, (transform.position), Quaternion.identity) as GameObject;

            timer = Time.deltaTime + 0.5f;
        }        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //during ringmode
        if(RingMode)
        {
            //if the collided object has a tag of "door" or "wall"
            if(col.transform.tag == ("Door") || col.transform.tag == ("Wall"))
            {           
                //deactivate ring mode                    
                RingMode = false;

                //trigger cooldown
                coolDownTriggered = true;

                //cancel movement
                Cancel();                
            }
        }        
    }

    void CoolDown()
    {
        //set timer
        coolDown -= 1 * Time.deltaTime;

        //when timer runs out
        if(coolDown <= 0)
        {
            //reset timer
            coolDown = 0.4F;

            //deactivate cooldown
            coolDownTriggered = false;
        }  
    }
}
