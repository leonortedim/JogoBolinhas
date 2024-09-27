using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    protected Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        RandomDirection();
    }

    public void RandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

        rb.velocity = randomDirection * speed;
    }
}
