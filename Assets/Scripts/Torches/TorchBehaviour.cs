using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehaviour : MonoBehaviour
{
    #region variables
    //booleans
    public bool ON = false;
    private bool intersected = false;

    //GameObject
    public GameObject flame;

    //Float
    private float timer = 0.5f;
    #endregion variables

    #region functions
    void Update ()
    {
        //set a timer if the torch is lit but the others in the set haven't
		if (ON && !transform.parent.GetComponent<TorchSetBehaviour>().allLit)
        {
            timer -= 1 * Time.deltaTime;
        }

        //when the timer runs out, the torch is "switched off"
        if(timer <= 0)
        {
            ON = false;
            timer = 0.5f;            
            intersected = false;            
        }
	}

    void OnTriggerStay(Collider fireRing)
    {
        //when inside the ring of fire, the torch is "on" and a flame is created
        if (fireRing.GetComponent<FireRingHitboxBehaviour>().incinerate && !intersected)
        {
            intersected = true;
            ON = true;

            GameObject flameInstance = Instantiate(flame, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity) as GameObject;

            flameInstance.transform.parent = this.transform;    
        }
    }
    #endregion functions
}
