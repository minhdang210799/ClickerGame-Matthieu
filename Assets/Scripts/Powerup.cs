using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Powerup : MonoBehaviour
{
    public float duration;
    public int powerEventId;
    public int resetEventId;
    [Header("Sound")]
    public AudioClip powerSound;
    public AudioClip resetSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventsHolder.instance.InvokeEvent(powerEventId);
            AudioManager.instance.PlaySound(powerSound);
            
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            if (duration < 0) yield break;

            yield return new WaitForSeconds(duration);

            EventsHolder.instance.InvokeEvent(resetEventId);
            AudioManager.instance.PlaySound(resetSound);

            Destroy(gameObject);
        }
    }
}
