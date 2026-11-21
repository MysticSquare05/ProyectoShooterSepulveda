using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;

    public int damage = 4;
    GameObject playerObj;
    int playerDir;
    void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    public void ShootBullet(int direction)
    {
        rb.linearVelocity = Vector2.right * speed * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.TakeDamage();
            Destroy(gameObject);
        }
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
