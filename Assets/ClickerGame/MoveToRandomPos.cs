using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRandomPos : MonoBehaviour
{
    public float speed;
    Vector3 destination;
    public Vector2 X;
    public Vector2 Y;

    // Start is called before the first frame update
    void Start()
    {
        GetRandomPosition(X.x, X.y, Y.x, Y.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != destination)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        else
        {
            GetRandomPosition(X.x, X.y, Y.x, Y.y);
        }
    }

    void GetRandomPosition(float minX, float maxX, float minY, float maxY)
    {
        float ranX = Random.Range(minX, maxX);
        float ranY = Random.Range(minY, maxY);

        destination = new Vector3(ranX, ranY);
    }
}
