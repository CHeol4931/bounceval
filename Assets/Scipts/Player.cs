using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpval;
    private Rigidbody2D rb;
    public Transform spawnPoint;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Move();
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(Vector2.up * jumpval, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Die"))
        {
            this.transform.position = spawnPoint.position;
        }
    }



}
