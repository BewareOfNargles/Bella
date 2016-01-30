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

    void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.PickUpWeapon(this);
        }
    }
}
