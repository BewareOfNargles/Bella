using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayRandomOnStart : MonoBehaviour
{
    public List<AudioClip> clips = new List<AudioClip>();

	// Use this for initialization
	void Start ()
    {
        AudioSource src = GetComponent<AudioSource>();
        if(src && clips.Count > 0)
        {
            src.PlayOneShot(PickRandom());
        }
	}

    AudioClip PickRandom()
    {
        return clips[Random.Range(0, clips.Count)];        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
