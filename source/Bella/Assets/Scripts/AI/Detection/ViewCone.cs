using UnityEngine;
using System.Collections;

public class ViewCone : MonoBehaviour
{
    NPCBehaviorController behaviorController;

	// Use this for initialization
	void Start()
	{
        behaviorController = GetComponentInParent<NPCBehaviorController>();
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
            Debug.Log("ViewCone collided with player!");
            if (player.equippedWeapon != Player.weapons.None)
            {
                behaviorController.SwitchState(NPCBehaviorController.NPCBehaviorStates.Suspicious);
            }

            return;
        }

        NPC npc = other.gameObject.GetComponent<NPC>();
        if (npc != null)
        {
            // We're safe even though our own view cone will trigger this, because we're not dead
            if (npc.IsDead)
            {
                behaviorController.SwitchState(NPCBehaviorController.NPCBehaviorStates.Suspicious);
            }
        }
    }
}
