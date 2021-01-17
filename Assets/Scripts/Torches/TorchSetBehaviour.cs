using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSetBehaviour : MonoBehaviour
{
    private float flameCounter = 0;

    public bool allLit = false;

    void Update ()
    {
        AddFlameCounter();
        OpenDoor();
    }

    void AddFlameCounter()
    {
        //for each torch
        foreach(Transform child in transform)
        {
            if(child.gameObject.transform.tag == ("Torch"))
            {
                //if it isn't lit, don't add to the counter
                if (child.GetComponent<TorchBehaviour>().ON == false)
                {
                    flameCounter = 0;
                    return;
                }

                //otherwise, add one if there isn't any more than 3 counts
                else if (child.GetComponent<TorchBehaviour>().ON == true && flameCounter <= 3)
                {
                    flameCounter = flameCounter + 1;
                }
            }            
        }
    }

    void OpenDoor()
    {
        //open door if three torches are open
        if(flameCounter >= 3)
        {
            allLit = true;

            foreach(Transform child in transform)
            {
                if (child.gameObject.transform.tag == ("Door"))
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
