using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score20 : MonoBehaviour
{
    public bool is20;
    private void OnCollisionEnter(Collision collision)
    {
        if(Score.bowScoreType == 0)
            Score.bowScoreType = 20;
        is20 = true;
    }
    
    private void OnCollisionStay(Collision collision)
    {
        is20 = false;
    }
    
    private void OnCollisionExit(Collision collision)
    {
        is20 = false;
    }
   
}
