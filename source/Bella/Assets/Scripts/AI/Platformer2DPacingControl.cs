﻿using UnityEngine;
using UnityStandardAssets._2D;
using System;
using System.Collections;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DPacingControl : NPCBehavior
{
    public int maxPaceDistance = 10;    // Max distance the character will pace in one direction if no obstacles are in the way

    [SerializeField]
    private LayerMask m_WhatIsGround;

    private PlatformerCharacter2D character;
    private Transform forwardGroundCheck;

    private int currentDirection = 0;
    public bool willBeGrounded = false;
    private bool turningAround = false;

    private const float k_GroundedRadius = 0.2f;

	// Use this for initialization
	void Start()
	{
        character = GetComponent<PlatformerCharacter2D>();
        forwardGroundCheck = transform.Find("ForwardGroundCheck");
        currentDirection = (UnityEngine.Random.Range(0, 2) == 0) ? -1 : 1;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
    
    void FixedUpdate()
    {
        willBeGrounded = false;

        // The player will be grounded if a circlecast to the forward groundcheck position hits anything designated as ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(forwardGroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                willBeGrounded = true;
            }
        }

        if (willBeGrounded || turningAround)
        {
            character.Move(currentDirection, false, false);
            turningAround = false;
        }
        else
        {
            character.Move(0, false, false);

            // Turn around!
            currentDirection *= -1;
            turningAround = true;
        }
    }
}
