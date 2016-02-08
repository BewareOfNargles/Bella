using UnityEngine;
using System.Collections;

public class RotationConstraints : Constraints
{
    protected override void ApplyConstraints()
    {
        if (transform.hasChanged)
        {
            Vector3 rotation = transform.localRotation.eulerAngles;

            rotation.x = Clamp(limitLowerX, limitUpperX, rotation.x, lowerLimitX, upperLimitX);
            rotation.y = Clamp(limitLowerY, limitUpperY, rotation.y, lowerLimitY, upperLimitY);
            rotation.z = Clamp(limitLowerZ, limitUpperZ, rotation.z, lowerLimitZ, upperLimitZ);

            //transform.localRotation.eulerAngles = rotation;
        }
    }
}
