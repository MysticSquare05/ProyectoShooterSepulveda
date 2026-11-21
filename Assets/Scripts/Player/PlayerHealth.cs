using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 20;

    public float iFrames = 2f;
    public float iFramesCounter;
    public bool isInvincible;
    public bool isHit;

    PlayerMovement player;
    Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMovement>();
    }
    public void Start()
    {
        isHit = false;
        isInvincible = false;
    }

    private void Update()
    {
        if (isInvincible && iFramesCounter > 0)
        {
            iFramesCounter -= Time.deltaTime;
        }
        else
        {
            isInvincible = false;
        }
    }

    private void FixedUpdate()
    {
        if (isHit)
        {
            Hit();
        }
    }

    public void LoseHealth(int damage)
    {
        health -= damage;
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!isInvincible)
            {

                int damage = collision.gameObject.GetComponent<EnemyBase>().damage;
                LoseHealth(damage);
                if (health <= 0)
                {
                    Die();
                }
                else
                {
                    isHit = true;
                }

            }
        }
    }
    void Die()
    {
        Destroy(gameObject);

    }

    void Hit()
    {
        isHit = false;

        if (!isInvincible)
        {
            isInvincible = true;
            iFramesCounter = iFrames;
            Vector2 knockbackForce = new Vector2(1300 * (player.facingDirection * -1), rb.linearVelocity.y + 300);
            rb.AddForce(knockbackForce);

        }
    }

    
}
