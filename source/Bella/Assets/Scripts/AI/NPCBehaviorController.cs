using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCBehaviorController : MonoBehaviour
{
    enum BehaviorStates
    {
        Pacing,
        Suspicious,
        Alarmed
    }

    // Behavioral components
    Dictionary<BehaviorStates, NPCBehavior> behaviors;

    // Logic
    BehaviorStates currentState = BehaviorStates.Pacing;
    Player player;



	// Use this for initialization
	void Start()
	{
        player = GameObject.FindObjectOfType<Player>();

        behaviors = new Dictionary<BehaviorStates, NPCBehavior>();
        behaviors.Add(BehaviorStates.Pacing, GetComponent<Platformer2DPacingControl>());
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

    public void OnPlayerInSight()
    {
        if (currentState == BehaviorStates.Pacing)
        {
            if (player.equippedWeapon != Player.weapons.None)
            {
                SwitchState(BehaviorStates.Suspicious);
            }
        }
    }

    private void SwitchState(BehaviorStates newState)
    {
        NPCBehavior behavior;
        if (behaviors.TryGetValue(currentState, out behavior))
        {
            behavior.Disable();
        }

        NPCBehavior newBehavior;
        if (behaviors.TryGetValue(newState, out newBehavior))
        {
            newBehavior.Enable();
        }

        currentState = newState;
    }

    public void OnDeath()
    {
        NPCBehavior pacingBehavior;
        if (behaviors.TryGetValue(BehaviorStates.Pacing, out pacingBehavior))
        {
            pacingBehavior.Disable();
        }
    }
}
