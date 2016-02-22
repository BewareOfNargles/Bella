using UnityEngine;
using UnityStandardAssets._2D;
using System.Collections;

public class Player : MonoBehaviour
{
    public static int NumberAlarmedNPCs = 0;

    public int maxBodies = 7;
    public int numBodies = 0;
    public int insanity = 0;
    public int maxInsanity = 100;
    public int dangerThreshold = 80;
    public int rateOfInsanityIncrease = 5;              // Per second
    public float insanityIncreaseMultiplier = 2.0f;     // When at least 1 NPC is alarmed, insanity will increase by insanityIncreaseMultiplier*rateOfInsanityIncrease per second
    public int speedLossPerBody = 0;                    // TODO: Implement this

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
                // TODO_OPTIMIZE: This can be done better, but I don't care right now and this is a 2d game so I'll probably never care. :D
                float multiplier = NumberAlarmedNPCs > 0 ? insanityIncreaseMultiplier : 1.0f;
                insanity += (int)(rateOfInsanityIncrease * multiplier);
                //Debug.Log("Insanity increased to " + insanity);
            }
        }
	}

    public void PickUpWeapon(Weapon weapon)
    {
        currentWeapon = weapon;

        //Debug.Log("Picked up weapon of type " + weapon.weaponType.ToString());

        Debug.Log("Picked up weapon of type " + weapon.weaponType.ToString());
        currentWeapon.PlayPickupSound();
    }

    public PlatformerCharacter2D GetCharacterController()
    {
        return controller;
    }

    void OnJump()
    {
        NPCSoundHelper sh = GetComponentInChildren<NPCSoundHelper>();
        if(sh)
        {
            sh.JumpSound();
        }
    }
}
