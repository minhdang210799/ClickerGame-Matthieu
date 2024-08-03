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

    // Restrictions
    float boundaryX;
    float boundaryY;

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

        onShoot.Invoke();

        GameObject _bullet = Instantiate(bullet, transform.position + Vector3.up, transform.rotation);
        Vector3 direction = transform.position + Vector3.up - transform.position;
        _bullet.GetComponent<Move>().direction = direction;
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
