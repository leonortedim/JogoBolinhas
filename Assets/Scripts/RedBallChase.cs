using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallChase : RedBall
{

    private Vector2 targetPosition;
    void Update()
    {
        
        rb.velocity = (targetPosition - (Vector2)transform.position).normalized * speed;
    }

    
    public void SetTargetPosition(Vector2 position)
    {
        targetPosition = position;
    }

    
}
