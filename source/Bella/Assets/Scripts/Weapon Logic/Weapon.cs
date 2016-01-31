using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public Player.weapons weaponType;
    public GameObject bulletPrefab;

    public Player player;

    public int numShots = 1;
    public int range = 1;
    
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
                /*GameObject bullet = (GameObject)*/Instantiate(bulletPrefab, startPoint.position, Quaternion.identity);
            }
        }

        Debug.Log("Fire! (Weapon type " + weaponType.ToString() + ")");
        numShots--;
        if (numShots == 0)
        {
            player.equippedWeapon = Player.weapons.None;
            Destroy(this);
        }
    }
}
