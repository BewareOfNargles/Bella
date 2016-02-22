using UnityEngine;
using System.Collections;

public class PendulumSwing : MonoBehaviour
{
    public float swingSpeed = 3.0f;
    public float amplitude = 30.0f;

    private bool isSwingingRight;
    public float rotationTolerance = 0.1f;

    private Quaternion leftmostRotation;
    private Quaternion rightmostRotation;

	// Use this for initialization
	void Start()
	{
        leftmostRotation = Quaternion.AngleAxis(amplitude*-1.0f, transform.forward);
        rightmostRotation = Quaternion.AngleAxis(amplitude, transform.forward);
	}
	
	// Update is called once per frame
	void Update()
	{
        if (isSwingingRight)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rightmostRotation, Time.deltaTime * swingSpeed);
            
            if (MathUtils.IsClose(transform.localRotation.eulerAngles.z, rightmostRotation.eulerAngles.z, rotationTolerance))
            {
                isSwingingRight = false;
            }
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, leftmostRotation, Time.deltaTime * swingSpeed);
            
            if (MathUtils.IsClose(transform.localRotation.eulerAngles.z, leftmostRotation.eulerAngles.z, rotationTolerance))
            {
                isSwingingRight = true;
            }
        }
	}
}
