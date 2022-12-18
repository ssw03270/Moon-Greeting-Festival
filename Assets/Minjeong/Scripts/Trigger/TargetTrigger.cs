using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public bool isTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
    }
}
