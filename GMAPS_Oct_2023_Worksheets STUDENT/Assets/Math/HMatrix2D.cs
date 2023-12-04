using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    public float[,] entries { get; set; } = new float[3, 3];

    public void SetIdentity()
{
    for (int y = 0; y < 3; y++) //loop through the rows y from 0 to < 3
    {
        for (int x = 0; x < 3; x++) //loop through the column x ffrom 0 to < 3
        {
            Entries[y, x] = (x == y) ? 1 : 0; //if the column x is equal to the rows y, set it to 1, if not, set to 0
        }
    }
}
//{
    //for (int y = 0; y < 3; y++)    //loop through the rows y from 0 to < 3
    //{
        //for (int x = 0; x < 3; x++)    // loop through the column x from 0 to < 3
        //{
            //if (x == y)    //checks if x=y
            //{
                //Entries[y, x] = 1;    //if true, set y and x = 1
            //}
            //else
            //{
                //Entries[y, x] = 0;    //if false, set y and x = 0
            //}
        //}
    //}
//}

    public HMatrix2D()
    {
        // your code here
    }

    public HMatrix2D(float[,] multiArray)
    {
         for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[y, x] = multiArray[y, x];
            }
    }
}

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        Entries[0, 0] = m00;
        Entries[0, 0] = m01;
        Entries[0, 0] = m02;

        Entries[0, 0] = m10;
        Entries[0, 0] = m11;
        Entries[0, 0] = m12;

        Entries[0, 0] = m20;
        Entries[0, 0] = m21;
        Entries[0, 0] = m22;
	
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] + right.Entries[y, x];
            }
        }

        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] - right.Entries[y, x];
            }
        }

        return result;
    }

    public static HMatrix2D operator *(HMatrix2D matrix, float scalar)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = matrix.Entries[y, x] * scalar;
            }
        }

        return result;
    }


    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y + left.Entries[0, 2] * 1.0f,
            left.entries[1, 0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * 1.0f
        )
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        //return new HMatrix2D
        (
	    /* 
            00 01 02    00 xx xx
            xx xx xx    10 xx xx
            xx xx xx    20 xx xx
            */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

	    /* 
            00 01 02    xx 01 xx
            xx xx xx    xx 11 xx
            xx xx xx    xx 21 xx
            */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

	    // and so on for another 7 entries
	);
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.Entries[y, x] != right.Entries[y, x])
                    return false;
        return true;
}

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        // your code here
    }

    public override bool Equals(object obj)
    {
        // your code here
    }

    public override int GetHashCode()
    {
        // your code here
    }

    public HMatrix2D transpose()
    {
        //return // your code here
    }

    public float getDeterminant()
    {
        //return // your code here
    }

    public void setIdentity()
    {
        // your code here
    }

    public void setTranslationMat(float transX, float transY)
    {
        // your code here
    }

    public void setRotationMat(float rotDeg)
    {
        // your code here
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}