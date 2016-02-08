using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCSoundHelper : MonoBehaviour
{
    public List<AudioClip> jumpSounds = new List<AudioClip>();
    public List<AudioClip> deathSounds = new List<AudioClip>();
    public List<AudioClip> suspiciousSounds = new List<AudioClip>();
    public List<AudioClip> alertedSounds = new List<AudioClip>();

    public AudioSource mumbleSource;
    private AudioSource mainAudioSource;

	// Use this for initialization
	void Start () {

        mainAudioSource = GetComponent<AudioSource>();
        if(!mainAudioSource)
        {
            enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    AudioClip PickRandom(List<AudioClip> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public void JumpSound()
    {
        if(jumpSounds.Count < 0)
        {
            return;
        }
        mainAudioSource.PlayOneShot(PickRandom(jumpSounds));
    }

    public void DeathSound()
    {
        if (deathSounds.Count < 0)
        {
            return;
        }
        mainAudioSource.PlayOneShot(PickRandom(deathSounds));

        // Disable mumbling
        if(mumbleSource != null)
        {
            mumbleSource.Stop();
        }
    }

    public void SuspiciousSound()
    {
        if (suspiciousSounds.Count < 0)
        {
            return;
        }
        mainAudioSource.PlayOneShot(PickRandom(suspiciousSounds));
    }

    public void AlertedSound()
    {
        if (alertedSounds.Count < 0)
        {
            return;
        }
        mainAudioSource.PlayOneShot(PickRandom(alertedSounds));
    }


}
