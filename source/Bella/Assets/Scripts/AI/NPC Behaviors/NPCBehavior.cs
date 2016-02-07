using UnityEngine;
using System.Collections;

public class NPCBehavior : MonoBehaviour
{
    protected NPCBehaviorController behaviorController;

	public virtual void Enable()
    {
        enabled = true;
    }

    public virtual void Disable()
    {
        enabled = false;
    }

    public void SetBehaviorController(NPCBehaviorController controller)
    {
        behaviorController = controller;
    }
}
