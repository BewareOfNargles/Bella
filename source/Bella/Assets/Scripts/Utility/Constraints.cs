using UnityEngine;
using System.Collections;

public class Constraints : MonoBehaviour
{
    public bool limitLowerX = false;
    public bool limitUpperX = false;
    public bool limitLowerY = false;
    public bool limitUpperY = false;
    public bool limitLowerZ = false;
    public bool limitUpperZ = false;

    public float lowerLimitX = 0.0f;
    public float upperLimitX = 0.0f;
    public float lowerLimitY = 0.0f;
    public float upperLimitY = 0.0f;
    public float lowerLimitZ = 0.0f;
    public float upperLimitZ = 0.0f;

    // Update is called once per frame
    void Update()
    {
        ApplyConstraints();
    }

    protected virtual void ApplyConstraints()
    {

    }

    protected float Clamp(bool limitLower, bool limitUpper, float current, float lowerBounds, float upperBounds)
    {
        float ret = current;

        if (limitLower)
        {
            ret = Mathf.Max(ret, lowerBounds);
        }

        if (limitUpper)
        {
            ret = Mathf.Min(ret, upperBounds);
        }

        return ret;
    }
}
