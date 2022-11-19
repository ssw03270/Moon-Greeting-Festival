using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketCollision : MonoBehaviour
{
   public bool isblanketcollision;
   public bool isBread;
   public bool isCake;
   public bool isPie;
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.transform.tag == "Bread")
      {
         isblanketcollision = true;
         isBread = true;
      }
      else if (collision.transform.tag == "Cake")
      {
         isblanketcollision = true;
         isCake = true;
      }
      else if (collision.transform.tag == "Pie")
      {
         isblanketcollision = true;
         isPie = true;
      }
      else
         isblanketcollision = false;
   }
}
