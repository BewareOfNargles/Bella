using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public Player.weapons weaponType;
    public GameObject bulletPrefab;

    [HideInInspector]
    public Player player;

    public int numShots = 1;
    public int range = 1;

    public List<AudioClip> pickupSounds = new List<AudioClip>();
    public List<AudioClip> fireSounds = new List<AudioClip>();

    // Use this for initialization
    void Start()
    {
	    
	}
	
	// Update is called once per frame
	void Update()
    {
	    if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Fire();
        }
	}

    void Fire()
    {
        if (bulletPrefab != null)
        {
            Transform startPoint = player.transform.Find("bulletStartPoint");
            if (startPoint != null)
            {
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, startPoint.position, Quaternion.identity);
                bullet.gameObject.GetComponent<Projectile>().directionMultiplier = player.GetCharacterController().GetDirectionMultiplier();
            }
        }

        PlayFireSound();

        Debug.Log("Fire! (Weapon type " + weaponType.ToString() + ")");
        numShots--;
        if (numShots == 0)
        {
            player.equippedWeapon = Player.weapons.None;
            Destroy(this);
        }
    }

    public void PlayFireSound()
    {
        if(fireSounds == null || fireSounds.Count < 1)
        {
            return;
        }

        AudioSource src = GetComponent<AudioSource>();
        if(src)
        {
            src.PlayOneShot(PickRandom(fireSounds));
        }
    }

    public void PlayPickupSound()
    {
        if (pickupSounds == null || pickupSounds.Count < 1)
        {
            return;
        }

        AudioSource src = GetComponent<AudioSource>();
        if (src)
        {
            src.PlayOneShot(PickRandom(pickupSounds));
        }
    }

    AudioClip PickRandom(List<AudioClip> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
