using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Threading.Tasks;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2d;
    float speed = 8f;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Move X", horizontal);
        animator.SetFloat("Move Y", vertical);

        float speed = Mathf.Sqrt(horizontal * horizontal + vertical * vertical);
        animator.SetFloat("Speed", speed);

    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedBall")
        {
            animator.SetTrigger("isDead");
            enabled = false;

            await Task.Delay(2000);
            SceneManager.LoadScene("DefeatScene");

        }
    }
}
