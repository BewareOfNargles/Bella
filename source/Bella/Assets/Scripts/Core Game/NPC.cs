using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{
    public NPCBehaviorController behaviorManager;

    private Animator animator;

	// Use this for initialization
	void Start()
	{
        animator = GetComponent<Animator>();
        behaviorManager = GetComponent<NPCBehaviorController>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

    [ContextMenu("Die")]
    public void Die()
    {
        // Trigger death animation, kill behaviors
        animator.SetTrigger("OnDeath");
        behaviorManager.OnDeath();

        // Remove view cone
        Destroy(transform.FindChild("ViewCone").gameObject);

        // Knock the NPC's hat off! Muahaha
        Transform hat = transform.FindChild("hat");
        hat.parent = null;
        Rigidbody2D hatRigidBody = hat.gameObject.AddComponent<Rigidbody2D>();
        hatRigidBody.AddForce(new Vector2(2.0f, 1.0f), ForceMode2D.Impulse);
    }
}
