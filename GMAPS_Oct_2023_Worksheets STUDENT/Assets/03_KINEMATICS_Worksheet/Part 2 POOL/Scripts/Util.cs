using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    HVector2D a = new HVector2D(8f, 5f);
    HVector2D b = new HVector2D(1f, 3f);
    float distance = Util.FindDistance(a, b);
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        float diffX = p2.x - p1.x; //calculates the difference between the x coordinates p1 - p2
        float diffY = p2.y - p1.y; //calculates the difference between the y coordinates p1 - p2
        
        return (float) Math.sqrt(diffX * diffX + diffY * diffY); //finds the distance between the points using pythagoras theorem
    }
}

