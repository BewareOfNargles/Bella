using UnityEngine;
using System.Collections;

public class ViewCone : MonoBehaviour
{
    NPCBehaviorManager behaviorManager;

	// Use this for initialization
	void Start()
	{
        behaviorManager = GetComponentInParent<NPCBehaviorManager>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            behaviorManager.OnPlayerInSight();
        }
    }
}
