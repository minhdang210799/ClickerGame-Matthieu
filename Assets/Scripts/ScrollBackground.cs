using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] Renderer background;
    public float scrollSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        background.material.mainTextureOffset -= new Vector2(0, -scrollSpeed * Time.deltaTime);
    }
}
