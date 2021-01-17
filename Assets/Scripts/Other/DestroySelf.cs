using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{    
    private float timer = 0;
    public float destroyThreshold;    

    void Update ()
    {       
        timer += Time.deltaTime;

        if (timer >= destroyThreshold)
        {
            Destroy(this.gameObject);
        }
    }
}
