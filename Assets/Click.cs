using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Click : MonoBehaviour
{
    public UnityEvent click;

    private void OnMouseDown()
    {
        
        if (TryGetComponent<Health>(out var health))
        {
            click.Invoke();
        }
    }

    public void AddPoint()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        canvas.GetComponent<Points>().AddPoint(1);
    }

    public void GameOver()
    {
        GameObject gameOver = GameObject.FindGameObjectWithTag("Canvas");
        gameObject.SetActive(true);
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }
}
