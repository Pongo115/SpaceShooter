using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 3f;         // Prêdkoœæ kuli
    public Transform playerTransform; // Transform gracza
    public Rigidbody2D rb;            // Rigidbody2D kuli
    private Vector3 direction;        // Kierunek ruchu kuli
    public GameObject bulletExplosionEffect; // Efekt eksplozji


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();


        direction = (playerTransform.position - transform.position).normalized;

        rb.velocity = direction * speed;

        RotateBullet();
    }


    void Update()
    {

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void RotateBullet()
    {

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

     
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f + 180f)); // Ustawienie rotacji o -90f + 180f
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.playerController.HittedByBullet(); // Gracz zosta³ trafiony
            Destroy(gameObject); // Zniszcz kulê
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(bulletExplosionEffect, transform.position, Quaternion.identity); // Efekt wybuchu
            Destroy(gameObject); // Zniszcz kulê
        }
    }
}