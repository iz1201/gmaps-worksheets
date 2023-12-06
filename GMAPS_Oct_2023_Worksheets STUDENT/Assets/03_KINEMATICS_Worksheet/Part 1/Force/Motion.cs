using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime; 

        float dx = Velocity.x * dt; //calculate the displacement along the x-axis by multiplying velocity.x and dt
        float dy = Velocity.y * dt; //calculate the displacement along the y-axis by multiplying velocity.y and dt
        float dz = Velocity.z * dt; //calculate the displacement along the z-axis by multiplying velocity.z and dt

        transform.Translate(new Vector3(dx, dy, dz)); //moves the object position by the calculated displacements along each axis by using transform.Translate
    }
}
