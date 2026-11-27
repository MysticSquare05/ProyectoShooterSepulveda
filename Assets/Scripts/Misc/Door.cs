using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Door : MonoBehaviour
{
    public Sprite closedDoorSpriteAsset;
    public Sprite openedDoorSpriteAsset;

    SpriteRenderer sr;

    bool isOpened = false;

    

    public ScoreHUD scoreHUD;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closedDoorSpriteAsset;
        isOpened = false;
    }

    public void OpenDoor()
    {
        sr.sprite = openedDoorSpriteAsset;
        isOpened = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isOpened)
            {

                scoreHUD.ShowWinScreen();
                //scoreHUD.faderActive = true;
                Destroy(gameObject);
            }
        }
    }

    
}
