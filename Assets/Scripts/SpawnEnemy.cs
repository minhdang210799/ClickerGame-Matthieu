using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    float boundaryX;

    public float spawnInterval;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        boundaryX = cam.orthographicSize * cam.aspect - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnInterval)
        {
            float ranX = Random.Range(-boundaryX, boundaryX);
            Instantiate(enemy, new Vector3(ranX, transform.position.y), Quaternion.identity);

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
