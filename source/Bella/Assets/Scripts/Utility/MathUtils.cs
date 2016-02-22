using UnityEngine;
using System.Collections;

public class MathUtils
{
    // Returns true if two floats have a difference equal to or less than the provided tolerance.
    // Useful for cases where you want a larger tolerance than Float.Epsilon, which Unity already
    // handles with float comparisons.
    public static bool IsClose(float a, float b, float tolerance)
    {
        if (Mathf.Abs(a-b) <= tolerance)
        {
            return true;
        }
        
        return false;
    }
}
