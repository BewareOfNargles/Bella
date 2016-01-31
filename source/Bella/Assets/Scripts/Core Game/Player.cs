using UnityEngine;
using UnityStandardAssets._2D;
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

    public Weapon currentWeapon = null;
    public weapons equippedWeapon = weapons.None;
    private float insanityTickTimer = 0.0f;

    private PlatformerCharacter2D controller;

    public enum weapons { None = 0, Knife = 1, Sword = 2, Pistol = 3, Rifle = 4 }

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<PlatformerCharacter2D>();
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
                //Debug.Log("Insanity increased to " + insanity);
            }
        }
	}

    public void PickUpWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        Debug.Log("Picked up weapon of type " + weapon.weaponType.ToString());
    }

<<<<<<< HEAD
    public PlatformerCharacter2D GetCharacterController()
    {
        return controller;
=======
    void OnJump()
    {
        NPCSoundHelper sh = GetComponentInChildren<NPCSoundHelper>();
        if(sh)
        {
            sh.JumpSound();
        }
>>>>>>> 705025158c8f7d4c2d61d8667d4fcebc5edc4c77
    }
}
