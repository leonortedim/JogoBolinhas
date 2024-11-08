using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallChase : RedBall
{
    private Vector2 moveDirection;

    void Update()
    {
        
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            moveDirection = (playerPosition - (Vector2)transform.position).normalized;

            rb.velocity = moveDirection * speed;
        }
    }

    public void SetTargetPosition(Vector2 position)
    {
        
        moveDirection = (position - (Vector2)transform.position).normalized;
    }
}
