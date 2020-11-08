using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameLinger : MonoBehaviour
{
    public float timer;
		
	void Update ()
    {
        Snuff();
	}

    void Snuff()
    {
        //if there are other torches in the set that aren't lit
        if(!transform.parent.parent.GetComponent<TorchSetBehaviour>().allLit)
        {
            //set the timer
            timer -= 1 * Time.deltaTime;

            //when the timer runs out
            if(timer <= 0)
            {
                //snuff out the flame
                Destroy(this.gameObject);
            }
        }
    }
}
