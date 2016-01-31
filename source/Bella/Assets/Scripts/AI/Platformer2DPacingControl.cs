using UnityEngine;
using UnityStandardAssets._2D;
using System;
using System.Collections;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DPacingControl : MonoBehaviour
{
    public int maxPaceDistance = 10;    // Max distance the character will pace in one direction if no obstacles are in the way

    private PlatformerCharacter2D character;
    private Transform forwardGroundCheck;

	// Use this for initialization
	void Start()
	{
        character = GetComponent<PlatformerCharacter2D>();
        forwardGroundCheck = transform.Find("ForwardGroundCheck");
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

    void FixedUpdate()
    {

    }
}
