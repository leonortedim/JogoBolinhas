using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    protected Rigidbody2D rb;
    private Vector3 originalScale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;

        GameManager.OnShrinkRedBalls += Shrink;
        GameManager.OnRestoreRedBalls += GrowBack;

        RandomDirection();
    }

void OnDestroy()
{
    // Unsubscribe from events to avoid memory leaks
    GameManager.OnShrinkRedBalls -= Shrink;
    GameManager.OnRestoreRedBalls -= GrowBack;
}

public void RandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

        rb.velocity = randomDirection * speed;
    }

    public void Shrink()
    {
        if (gameObject.CompareTag("RedBall")) 
        {
            transform.localScale = originalScale * 0.5f;
        }
            
    }

    public void GrowBack()
    {
        if (gameObject.CompareTag("RedBall"))
        {
            transform.localScale = originalScale;
        }
    }
}
