using UnityEngine;
using System.Collections;

public class ScaleConstraints : Constraints
{
    protected override void ApplyConstraints()
    {
        if (transform.hasChanged)
        {
            Vector3 scale = transform.localScale;

            scale.x = Clamp(limitLowerX, limitUpperX, scale.x, lowerLimitX, upperLimitX);
            scale.y = Clamp(limitLowerY, limitUpperY, scale.y, lowerLimitY, upperLimitY);
            scale.z = Clamp(limitLowerZ, limitUpperZ, scale.z, lowerLimitZ, upperLimitZ);

            transform.localScale = scale;
        }
    }
}
