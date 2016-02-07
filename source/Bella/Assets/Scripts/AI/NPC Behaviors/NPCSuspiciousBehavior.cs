using UnityEngine;
using System.Collections;

public class NPCSuspiciousBehavior : NPCBehavior
{
    // Tunables
    public float timeBeforeBecomingAlarmed = 3.0f;

    // Logic/components
    private float alarmTimer = 0.0f;
    private GameObject suspiciousIcon;
    
	// Use this for initialization
	void Start()
	{
        suspiciousIcon = transform.FindChild("status_suspicious").gameObject;
	}
	
	// Update is called once per frame
	void Update()
	{
        alarmTimer += Time.deltaTime;

        if (alarmTimer >= timeBeforeBecomingAlarmed)
        {
            behaviorController.SwitchState(NPCBehaviorController.NPCBehaviorStates.Alarmed);
        }
	}

    public override void Enable()
    {
        base.Enable();

        // Attach suspicious icon
        suspiciousIcon.SetActive(true);
    }

    public override void Disable()
    {
        base.Disable();

        // Reset timer
        alarmTimer = 0.0f;

        // Detach suspicious icon
        suspiciousIcon.SetActive(false);
    }
}
