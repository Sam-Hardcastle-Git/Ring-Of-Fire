using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    #region variables
    private float timer = 0;
    public float destroyThreshold;
    #endregion variables

    #region functions
    void Update ()
    {       
        timer += Time.deltaTime;

        if (timer >= destroyThreshold)
        {
            Destroy(this.gameObject);
        }
	}
    #endregion functions
}
