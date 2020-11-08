using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    #region variables

    //direction enum
    public enum direction { horizontal , vertical };
    public direction objectDirection;

    //boolean
    public bool positive = false;

    //floats
    public float speed;
    public float boundaries;

    //vector3
    public Vector3 startingPosition;

    #endregion variables

    #region functions
    void Start ()
    {
        startingPosition = transform.position;        
	}
	
	void Update ()
    {
        Movement();
	}

    void Movement()
    {
        switch (objectDirection)
        {
            #region vertical
            case direction.vertical:
                if (transform.position.y <= startingPosition.y - boundaries && !positive)
                {
                    positive = true;
                }

                if (transform.position.y >= startingPosition.y + boundaries && positive)
                {
                    positive = false;
                }

                if (positive)
                {
                    transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                }

                if (!positive)
                {
                    transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                }
            break;
            #endregion vertical

            #region horizontal
            case direction.horizontal:

                if (transform.position.x <= startingPosition.x - boundaries && !positive)
                {
                    positive = true;
                }

                if (positive)
                {
                    transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }

                if (transform.position.x >= startingPosition.x + boundaries && positive)
                {
                    positive = false;
                }

                if (!positive)
                {
                    transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                }
            break;
            #endregion horizontal
        }
    }
    #endregion functions
}
