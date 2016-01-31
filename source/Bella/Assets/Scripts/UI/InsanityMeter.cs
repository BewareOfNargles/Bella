using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InsanityMeter : MonoBehaviour {
    public Player uiPlayerTracker;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
       
        GetComponent<Slider>().value = ((float)uiPlayerTracker.insanity / (float)uiPlayerTracker.maxInsanity) * 100.0f;
    }
}