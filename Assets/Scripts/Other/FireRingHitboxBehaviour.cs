using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingHitboxBehaviour : MonoBehaviour
{
    #region variables
    //GameObjects
    private GameObject playableCharacter;
    public GameObject Blast;

    //Boolean
    public bool incinerate = false;

    //Float
    private float timer = 0.1f;
    #endregion variables

    #region functions

    void Start ()
    {
        playableCharacter = GameObject.FindGameObjectWithTag("Player");
    }
		
	void Update ()
    {
        //if the player isn't in RingMode
	    if(!playableCharacter.GetComponent<PCRingOfFire>().RingMode)
        {
            //set incinerate to true
            incinerate = true;

            //create a hitbox
            Instantiate(Blast, transform.position, Quaternion.identity);

            //start the timer
            timer -= 1 * Time.deltaTime;
            
            //when time is up, destroy the hitbox
            if (timer <= 0)
            {
                Destroy(this.gameObject);
            }           
        }	
	}

    #endregion functions
}
