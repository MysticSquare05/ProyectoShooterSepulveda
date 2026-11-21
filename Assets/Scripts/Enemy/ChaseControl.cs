using UnityEngine;

public class ChaseControl : MonoBehaviour
{
    public ChonChon[] chonChonArray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            foreach (ChonChon enemy in chonChonArray)
            {
                enemy.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (ChonChon enemy in chonChonArray)
            {
                enemy.chase = false;
            }
        }
    }
}
