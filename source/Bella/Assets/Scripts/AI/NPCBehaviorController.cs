using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCBehaviorController : MonoBehaviour
{
    public enum NPCBehaviorStates
    {
        Pacing,
        Suspicious,
        Alarmed
    }

    // Behavioral components
    Dictionary<NPCBehaviorStates, NPCBehavior> behaviors;

    // Logic
    NPCBehaviorStates currentState = NPCBehaviorStates.Pacing;

	// Use this for initialization
	void Start()
	{
        behaviors = new Dictionary<NPCBehaviorStates, NPCBehavior>();

        AddBehavior(NPCBehaviorStates.Pacing, GetComponent<Platformer2DPacingControl>());
        AddBehavior(NPCBehaviorStates.Suspicious, GetComponent<NPCSuspiciousBehavior>());
        AddBehavior(NPCBehaviorStates.Alarmed, GetComponent<NPCAlarmedBehavior>());
	}

    private void AddBehavior(NPCBehaviorStates state, NPCBehavior behavior)
    {
        behavior.SetBehaviorController(this);
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
        // Our NPC has died, so kill all running behaviors
        foreach(KeyValuePair<NPCBehaviorStates, NPCBehavior> behaviorPair in behaviors)
        {
            behaviorPair.Value.Disable();
        }
    }
}
