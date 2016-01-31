using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Insanityflash : MonoBehaviour {
    public Player uiPlayerTracker;
    // Use this for initialization
    void Start () {
        GetComponent<Image>().CrossFadeAlpha((float)0, (float)0, false);
    }
	
	// Update is called once per frame
	void Update () {
	if(uiPlayerTracker.insanity >= uiPlayerTracker.dangerThreshold)
        {
           GetComponent<Image>().CrossFadeAlpha((float)1.0, (float)2.0,false);
        }
	}
}
