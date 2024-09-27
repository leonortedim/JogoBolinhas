using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenBall : Ball
{
    [SerializeField] Score score;
   
    public GameObject redBallPrefab; 
    public GameObject redBallChasePrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            score.ChangeScore();

            transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));

            RandomDirection();

           


            

            int randomNumber = Random.Range(0, 2);

            if (randomNumber == 0)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
                Instantiate(redBallPrefab, randomPosition, Quaternion.identity);
            }
            else
            {
                Vector2 playerPosition = collision.transform.position;

                SpawnRedBall(playerPosition);

            }
        }
    }

    void SpawnRedBall(Vector2 playerPosition)
    {
       
        GameObject redBall = Instantiate(redBallChasePrefab, transform.position, Quaternion.identity);

      
        RedBallChase redBallScript = redBall.GetComponent<RedBallChase>();
        redBallScript.SetTargetPosition(playerPosition);
    }

}

