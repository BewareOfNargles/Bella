using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCBehaviorController : MonoBehaviour
{
    public enum NPCBehaviorStates
    {
        Pacing,
        Suspicious,
        Alarmed,
        Dead
    }

    // Behavioral components
    Dictionary<NPCBehaviorStates, NPCBehavior> behaviors;

    // Logic
    NPCBehaviorStates currentState = NPCBehaviorStates.Pacing;

	// Use this for initialization
	void Start()
	{
        behaviors = new Dictionary<NPCBehaviorStates, NPCBehavior>();

        Platformer2DPacingControl pacingBehavior = GetComponent<Platformer2DPacingControl>();
        AddBehavior(NPCBehaviorStates.Pacing, pacingBehavior);
        pacingBehavior.Enable();

        AddBehavior(NPCBehaviorStates.Suspicious, GetComponent<NPCSuspiciousBehavior>());
        AddBehavior(NPCBehaviorStates.Alarmed, GetComponent<NPCAlarmedBehavior>());
	}

    private void AddBehavior(NPCBehaviorStates state, NPCBehavior behavior)
    {
        behavior.SetBehaviorController(this);
        behavior.Disable();
        behaviors.Add(state, behavior);
    }

    public void SwitchState(NPCBehaviorStates newState)
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
        if (currentState != NPCBehaviorStates.Dead)
        {
            // Our NPC has died, so kill all running behaviors
            foreach (KeyValuePair<NPCBehaviorStates, NPCBehavior> behaviorPair in behaviors)
            {
                behaviorPair.Value.Disable();
            }

            currentState = NPCBehaviorStates.Dead;
        }
    }
}
