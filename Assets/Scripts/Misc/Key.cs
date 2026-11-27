using UnityEngine;

public class Key : MonoBehaviour
{

    public Door doorObject;
    public ScoreHUD scoreHUD;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorObject.OpenDoor();
            scoreHUD.ShowKeyHUD();
            Destroy(gameObject);
        }
    }
}
