using UnityEngine;
using System.Collections;

public class PositionConstraints : Constraints
{
    protected override void ApplyConstraints()
    {
        if (transform.hasChanged)
        {
            Vector3 position = transform.localPosition;

            position.x = Clamp(limitLowerX, limitUpperX, position.x, lowerLimitX, upperLimitX);
            position.y = Clamp(limitLowerY, limitUpperY, position.y, lowerLimitY, upperLimitY);
            position.z = Clamp(limitLowerZ, limitUpperZ, position.z, lowerLimitZ, upperLimitZ);

            transform.localPosition = position;
        }
    }
}
