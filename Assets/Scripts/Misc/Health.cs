using UnityEngine;

public class Health : MonoBehaviour
{

    public float rotationYSpeed = 720;
    public ScoreHUD scoreHUD;

    private void Update()
    {
        transform.Rotate(transform.rotation.x, rotationYSpeed * Time.deltaTime, transform.rotation.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().lives++;
            scoreHUD.RefreshLives();
            Destroy(gameObject);


        }
    }

}
