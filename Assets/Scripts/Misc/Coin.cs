using UnityEngine;

public class Coin : MonoBehaviour
{

    public float rotationYSpeed = 720;

    private void Update()
    {
        transform.Rotate(transform.rotation.x, rotationYSpeed * Time.deltaTime, transform.rotation.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().AddScore(200);
            Destroy(gameObject);


        }
    }

}
