using UnityEngine;
using System.Collections;

public class NPCAlarmedBehavior : Platformer2DPacingControl
{
    // Logic/components
    private GameObject alarmedIcon;

    // Use this for initialization
    protected override void Start()
	{
        base.Start();
        
        alarmedIcon = transform.FindChild("status_alert").gameObject;
    }

    public override void Enable()
    {
        base.Enable();

        // Attach alarmed icon
        alarmedIcon.SetActive(true);

        // Increase alarmed NPC counter, as we've become alarmed.
        Player.NumberAlarmedNPCs++;
    }

    public override void Disable()
    {
        base.Disable();

        // Detach alarmed icon
        alarmedIcon.SetActive(false);

        // Decrease alarmed NPC counter, as we're no longer alarmed (we probably died. D:)
        Player.NumberAlarmedNPCs--;
    }
}
