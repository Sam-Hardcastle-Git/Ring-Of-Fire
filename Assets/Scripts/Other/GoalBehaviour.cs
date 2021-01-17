using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == ("Player"))
        {
            GameObject.FindObjectOfType<LevelManagerScript>().LoadEndScene();
        }
    }
}
