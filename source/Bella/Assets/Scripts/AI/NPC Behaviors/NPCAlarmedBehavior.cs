using UnityEngine;
using System.Collections;

public class NPCAlarmedBehavior : NPCBehavior
{
    // Logic/components
    private GameObject alarmedIcon;

    // Use this for initialization
    void Start()
	{
        alarmedIcon = transform.FindChild("status_alert").gameObject;
    }
	
	// Update is called once per frame
	void Update()
	{
		
	}

    public override void Enable()
    {
        base.Enable();

        // Attach alarmed icon
        alarmedIcon.SetActive(true);
    }

    public override void Disable()
    {
        base.Disable();

        // Detach alarmed icon
        alarmedIcon.SetActive(false);
    }
}
