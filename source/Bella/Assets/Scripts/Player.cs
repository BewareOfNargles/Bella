﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int maxBodies = 7;
    public int numBodies = 0;
    public int insanity = 0;
    public int maxInsanity = 100;
    public int dangerThreshold = 80;
    public int rateOfInsanityIncrease = 5;  // Per second

    public int speedLossPerBody = 0;

    private float insanityTickTimer = 0.0f;
    
	// Use this for initialization
	void Start()
    {
	    
	}
	
	// Update is called once per frame
	void Update()
    {
        if (insanity < maxInsanity)
        {
            insanityTickTimer += Time.deltaTime;

            if (insanityTickTimer >= 1)
            {
                insanityTickTimer = 0;
                insanity += rateOfInsanityIncrease;
                Debug.Log("Insanity increased to " + insanity);
            }
        }
	}
}
