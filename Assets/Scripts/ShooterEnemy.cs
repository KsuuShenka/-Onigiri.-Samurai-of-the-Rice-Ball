using System.Collections;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform firePoint;
    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        currentBulletVelocity.velocity = new Vector2(bulletSpeed * -1, currentBulletVelocity.velocity.y);

        StartCoroutine(StopShootCoroutine());
        IEnumerator StopShootCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(currentBullet);
        }
    }
}
