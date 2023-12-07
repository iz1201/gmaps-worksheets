using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];
    public float h;
    public float x;
    public float y;

    public HMatrix2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HMatrix2D(float[,] multiArray)
    {
         for (int y = 0; y < 3; y++) //loop through the rows y from 0 to < 3. 3 rows
        {
            for (int x = 0; x < 3; x++) //loop through the column x ffrom 0 to < 3. 3 columns
            {
                Entries[y, x] = multiArray[y, x]; //assigns the value from multiArray and puts them into Entries. This fills up the new matrix with the given numbers.
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
        HMatrix2D result = new HMatrix2D(); //creates a new matrix to put the result

        for (int y = 0; y < 3; y++) 
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] + right.Entries[y, x]; //this adds the values in the same position of both matrix and puts the result in the new matrix
            }
        }

        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D(); //creates a new matrix to put the result

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] - right.Entries[y, x]; //subtracts the value of the elements in the same position of both matrix and puts result in new matrix
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
            left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * 1.0f
        );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
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
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],

            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2] 
            
	   );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.Entries[y, x] != right.Entries[y, x]) //checks if left and right is not equal
                    return false; //if not equal, return false means matrices are not equal
        return true; //otherwise return true means matrices are equal
}

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.Entries[y, x] != right.Entries[y, x]) //checks if left and right is not equal
                    return true; //if not equal, return true means matrices are not equal
        return false; //otherwise return false meaning matrices are equal
}


    public void SetIdentity()
    {
    for (int y = 0; y < 3; y++) //loop through the rows y from 0 to < 3. 3 rows
    {
        for (int x = 0; x < 3; x++) //loop through the column x ffrom 0 to < 3. 3 columns
        {
            Entries[y, x] = (x == y) ? 1 : 0; //if the column x is equal to the rows y, set it to 1, if not, set to 0
        }
    }
}
//{
    //for (int y = 0; y < 3; y++)   
    //{
        //for (int x = 0; x < 3; x++)   
        //{
            //if (x == y) 
            //{
                //Entries[y, x] = 1; 
            //}
            //else
            //{
                //Entries[y, x] = 0;
            //}
        //}
    //}
//}

    public void SetTranslationMat(float transX, float transY)
    {
        Entries[0, 2] = transX; //set translation in X direction
        Entries[1, 2] = transY; //set translation in Y direction
    }

    public void SetRotationMat(float rotDeg)
    {
        //  cos x  -sin x
        //  sin x   cos x

        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad; //converts rotation degree to radians
        Entries[0, 0] = Mathf.Cos(rad); //assigns the cos of the calculated radian angle to [0, 0]
        Entries[0, 1] = -Mathf.Sin(rad); //assigns the -sin of the calculated radian angle to [0, 1]
        Entries[1, 0] = Mathf.Sin(rad); //assigns the sin of the calculated radian angle to [1, 0]
        Entries[1, 1] = Mathf.Cos(rad); //assigns the cos of the calculated radian angle to [1, 1]
}

    public void SetScalingMat(float scaleX, float scaleY)
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
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}