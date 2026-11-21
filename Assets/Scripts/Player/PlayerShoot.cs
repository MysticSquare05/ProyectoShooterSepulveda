using UnityEngine;

public class PlayerShoot : MonoBehaviour

{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.ShootBullet(playerMovement.facingDirection);
    }
}
