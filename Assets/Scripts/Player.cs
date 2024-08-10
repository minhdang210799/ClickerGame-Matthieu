using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Moving")]
    public float moveSpeed;
    Vector3 mousePos;

    [Header("Shooting")]
    public GameObject bullet;
    public float shootDelay;
    float shootTimer;
    public UnityEvent onShoot;
    public int bulletCount = 1;
    public float bulletSpread;

    // Restrictions
    float boundaryX;
    float boundaryY;

    [Header("Effects")]
    public ParticleSystem shootParticle;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        boundaryX = cam.orthographicSize * cam.aspect - 0.5f;
        boundaryY = cam.orthographicSize - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }

        shootTimer -= Time.deltaTime;

        Restrict();
    }

    void Move()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (shootTimer > 0)
        {
            return;
        }

        shootTimer = shootDelay;

        Instantiate(shootParticle, transform.position + new Vector3(0, 0.5f), Quaternion.identity);

        if (bulletCount <= 1)
        {
            GameObject _bullet = Instantiate(bullet, transform.position + Vector3.up * 2, transform.rotation);
            Vector3 direction = transform.up;
            _bullet.GetComponent<Move>().direction = direction;
        }
        /*else
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - bulletSpread / 2);
            Debug.Log(transform.eulerAngles.z - (bulletSpread / 2));
            for (int i = 0; i < bulletCount; i++)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + bulletSpread);
                Debug.Log(transform.rotation.eulerAngles.z + bulletSpread);
                Instantiate(bullet, transform.position + Vector3.up * 2, transform.rotation).GetComponent<Move>().direction = transform.up;
                //Vector3 direction = transform.up;
                //_bullet.GetComponent<Move>().direction = direction;
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);

            //Instantiate(bullet, transform.position + Vector3.up * 2, transform.rotation).GetComponent<Move>().direction = transform.up;
        }*/

        onShoot.Invoke();
    }

    // Makes sure the player doesn't go off screen.
    void Restrict()
    {
        if (transform.position.x > boundaryX)
        {
            transform.position = new Vector3(boundaryX, transform.position.y);
        }
        if (transform.position.x < -boundaryX)
        {
            transform.position = new Vector3(-boundaryX, transform.position.y);
        }
        if (transform.position.y > boundaryY)
        {
            transform.position = new Vector3(transform.position.x, boundaryY);
        }
        if (transform.position.y < -boundaryY)
        {
            transform.position = new Vector3(transform.position.x, -boundaryY);
        }
    }
}
