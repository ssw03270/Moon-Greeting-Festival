using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampTrigger : MonoBehaviour
{
    public bool stamptrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stamp")
        {
            stamptrigger = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Stamp")
        {
            stamptrigger = false;
        }
    }
    
}
