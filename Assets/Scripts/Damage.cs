using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public bool destroyOnImpact;
    public bool destroyOnDamage;
    public ParticleSystem damageParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet")) return;

        if (collision.collider.TryGetComponent(out Health health))
        {
            health.Damage(damage);

            if (damageParticle != null)
            {
                Instantiate(damageParticle, transform.position, Quaternion.identity);
            }

            if (destroyOnImpact && destroyOnDamage)
            {
                Destroy(gameObject);
            }
        }

        if (destroyOnImpact)
        {
            Destroy(gameObject);
        }
    }
}
