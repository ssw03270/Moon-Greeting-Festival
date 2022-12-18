using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public bool isTrigger1 = false;
    public bool isTrigger2 = false;
    public bool isTrigger3 = false;
    public bool isTrigger4 = false;
    public bool isTrigger5 = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arrow1")
        {
            isTrigger1 = true;
            
        }
        if (other.tag == "Arrow2")
        {
            isTrigger2 = true;
            
        }
        if (other.tag == "Arrow3")
        {
            isTrigger3 = true;
            
        }
        if (other.tag == "Arrow4")
        {
            isTrigger4 = true;
            
        }
        if (other.tag == "Arrow5")
        {
            isTrigger5 = true;
            
        }
    }

 
}
