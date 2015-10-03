 using System.Collections;
 using UnityEditor;
 using UnityEngine;

 namespace DT {
   public static class EventExtensions {
     public static Vector3 MouseWorldPosition(this Event e) {
       Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
       return ray.origin;
     }
   }
 }
