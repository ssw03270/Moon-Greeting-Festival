using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimation : MonoBehaviour
{
    public float targetPosition1;
    public float targetPosition2;
    public float x;

    private bool isForward = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < targetPosition1 && transform.position.z < targetPosition2)
        {
            isForward = true;
            transform.rotation = Quaternion.Euler(new Vector3(x, 0 , 0));
        }
        if (transform.position.z > targetPosition1 && transform.position.z > targetPosition2)
        {
            isForward = false;
            transform.rotation = Quaternion.Euler(new Vector3(x, 0 , 180));
            if (transform.name == "General_pose")
            {
                transform.rotation = Quaternion.Euler(new Vector3(180, 0 , 180));
            }
        }

        if (isForward)
        {
            transform.position += new Vector3(0, 0, Time.deltaTime);
        }
        else
        {
            transform.position += new Vector3(0, 0, -1 * Time.deltaTime);
        }
    }
}
