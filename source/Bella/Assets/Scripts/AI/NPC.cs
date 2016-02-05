using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{
    public NPCBehaviorManager behaviorManager;

    private Animator animator;

	// Use this for initialization
	void Start()
	{
        animator = GetComponent<Animator>();
        behaviorManager = GetComponent<NPCBehaviorManager>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

    [ContextMenu("Death")]
    public void Die()
    {
        animator.SetTrigger("OnDeath");
        behaviorManager.OnDeath();
    }
}
