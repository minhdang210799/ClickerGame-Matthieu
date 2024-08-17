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
    public int bulletCount = 1;
    public float bulletSpread;

    // Restrictions
    float boundaryX;
    float boundaryY;

    [Header("Effects")]
    public ParticleSystem shootParticle;
    public AudioClip shootSound;

    [Header("Powerups")]
    float startShootSpeed;
    int startBulletCount;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        boundaryX = cam.orthographicSize * cam.aspect - 0.5f;
        boundaryY = cam.orthographicSize - 0.5f;

        startShootSpeed = shootDelay;
        startBulletCount = bulletCount;
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
            GameObject _bullet = Instantiate(bullet, transform.position + Vector3.up * 0.5f, transform.rotation);
            Vector3 direction = transform.up;
            _bullet.GetComponent<Move>().direction = direction;
            Destroy(_bullet, 5f);
        }
        else
        {
            transform.Rotate(0, 0, -(bulletSpread / 2));
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject _bullet = Instantiate(bullet, transform.position + Vector3.up * 0.5f, transform.rotation);
                Vector3 direction = transform.up;
                _bullet.GetComponent<Move>().direction = direction;
                transform.Rotate(0, 0, bulletSpread / (bulletCount - 1));
                Destroy(_bullet, 5f);
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        AudioManager.instance.PlaySound(shootSound);
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

    public void SetFirerate(float firerate)
    {
        shootDelay = firerate;
    }

    public void ResetFirerate()
    {
        shootDelay = startShootSpeed;
    }

    public void SetBulletCount(int bullets)
    {
        bulletCount = bullets;
    }

    public void ResetBulletCount()
    {
        bulletCount = startBulletCount;
    }
}
