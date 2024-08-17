using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public bool isInvincible = false;
    [Space]
    public UnityEvent onDeath;
    [Space]
    public AudioClip deathSound;
    public ParticleSystem deathParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        if (isInvincible) return;

        health -= damage;

        if (health <= 0)
        {
            if (deathParticle != null)
            {
                Instantiate(deathParticle, transform.position, Quaternion.identity);
            }
            onDeath.Invoke();
            if (gameObject.CompareTag("Enemy")) EventsHolder.instance.InvokeEvent(6);
            AudioManager.instance.PlaySound(deathSound);
        }
    }

    public void SetInvincible(bool invincible)
    {
        isInvincible = invincible;
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
