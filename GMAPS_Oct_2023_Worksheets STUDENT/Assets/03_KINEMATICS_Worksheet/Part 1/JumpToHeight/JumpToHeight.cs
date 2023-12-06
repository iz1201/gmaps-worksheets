using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
     public float Height = 1f;
     Rigidbody rb;

     private void Start()
     {
         rb = GetComponent<Rigidbody>(); //get rigid body component
     }

     void Jump()
     {
          //v*v = u*u + 2as
          //u*u = v*v - 2as
          //u = sqrt(v*v - 2as)
          //v = 0, u = ?, a = Physics.gravity, s = Height

         float u = Mathf.Sqrt(-2 * Physics.gravity.y * Height); //calculates the initial velocity u
         rb.velocity = new Vector3(0, u, 0); //sets rigidbody velocity to make object jump with 'u' velocity in the y axis

     }

     private void Update()
     {
         if(Input.GetKeyDown(KeyCode.Space)) //checks if space is press
         {
             Jump(); //calls the jump method
         }
     }
 }

