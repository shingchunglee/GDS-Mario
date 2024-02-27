using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Movement_Extension 
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");
   public static bool Raycast(this Rigidbody2D e_rigidbody, Vector2 direction)
   {
     if (e_rigidbody.isKinematic) {
        return false;
     }
     float radius = 0.25f;
     float distance = 0.375f;

     RaycastHit2D hit = Physics2D.CircleCast(e_rigidbody.position, radius, direction, distance, layerMask);
     return hit.collider != null && hit.rigidbody != e_rigidbody;
   }
    
}
