using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int speed = 5;
    public int range = 1;

    [HideInInspector]
    public int directionMultiplier = 1;

    public int maxLifetime = 10;    // Just in case there's nothing to collide with, kill the projectile after this many seconds
    private float lifeTimer = 0.0f;

    private Rigidbody2D m_rigidBody2D;
    private Vector2 m_velocity;

    // Use this for initialization
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_velocity = new Vector2(speed * directionMultiplier, 0.0f);

        transform.localScale *= directionMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Remove this line once speed has been polished
        m_velocity.x = speed * directionMultiplier;

        lifeTimer += Time.deltaTime;
        if (lifeTimer >= maxLifetime)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        m_rigidBody2D.velocity = m_velocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // We don't care if the bullet collided with the player.
        if (other.gameObject.GetComponent<Player>() == null &&
            other.gameObject.GetComponent<Projectile>() == null &&
            other.gameObject.GetComponent<WeaponPickup>() == null)
        {
            NPC npc = other.gameObject.GetComponent<NPC>();
            if (npc != null)
            {
                npc.Die();
            }

            Destroy(gameObject);
        }
    }
}
