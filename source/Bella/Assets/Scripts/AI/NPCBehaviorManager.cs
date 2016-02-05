using UnityEngine;
using System.Collections;

public class NPCBehaviorManager : MonoBehaviour
{
    public Platformer2DPacingControl pacingBehavior;

	// Use this for initialization
	void Start()
	{
        pacingBehavior = GetComponent<Platformer2DPacingControl>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

    public void OnDeath()
    {
        pacingBehavior.enabled = false;
    }
}
