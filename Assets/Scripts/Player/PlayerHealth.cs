using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;
    public Transform respawnPoint;
    PlayerMovement player;
    Rigidbody2D rb;
    public ScoreHUD scoreHUD;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMovement>();
    }
    public void Start()
    {
        
        
    }

    private void Update()
    {

        if (transform.position.y < -5)
        {
            Die();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }
    void Die()
    {
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            transform.position = respawnPoint.position;
            rb.linearVelocity = Vector2.zero;
        }
        scoreHUD.RefreshLives();
    }

    

    
}
