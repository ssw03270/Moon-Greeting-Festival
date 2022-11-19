using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isTrigger = false;
    private Color m_oldColor = Color.white;
    private void OnTriggerEnter(Collider other)
    {
        Renderer render = GetComponent<Renderer>();

        m_oldColor = render.material.color;
        render.material.color = Color.green;
        isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = m_oldColor;
        isTrigger = false;
    }

   
    
}
