using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

	void Start ()
    {
		player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!player.GetComponent<PCRingOfFire>().RingMode)

        transform.position = player.transform.position + new Vector3(0,2,-10);
	}
}
