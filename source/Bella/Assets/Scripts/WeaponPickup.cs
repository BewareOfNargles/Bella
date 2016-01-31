using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{
	// Use this for initialization
	void Start()
    {

	}
	
	// Update is called once per frame
	void Update()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            // Grab the weapon component
            Weapon weapon = GetComponent<Weapon>();

            if (weapon != null)
            {
                // Ready the weapon!
                weapon.player = player;
                weapon.enabled = true;

                // Kill the world sprite, it's not needed anymore.
                SpriteRenderer worldSprite = GetComponentInChildren<SpriteRenderer>();
                if (worldSprite)
                {
                    Destroy(worldSprite);
                }

                // TODO: This line probably isn't even necessary?
                player.PickUpWeapon(weapon);
                // Set the player's correct equipped weapon type
                player.equippedWeapon = weapon.weaponType;

                // Kill the pickup logic!
                Destroy(this);
            }
        }
    }
}
