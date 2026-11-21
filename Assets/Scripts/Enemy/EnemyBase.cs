using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int health;
    public int damage;
    
    public void TakeDamage()
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
