using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float shootRange = 6f;
    public float fireRate = 0.5f;
    float fireTimer;

    void Start()
    {

    }
    void Update()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0)
        {
            TryShoot();
            fireTimer = fireRate;
        }
    }

    void TryShoot()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Enemy nearest = null;
        float shortest = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            float dist = Vector2.Distance(transform.position, e.transform.position);
            if (dist < shortest && dist <= shootRange)
            {
                shortest = dist;
                nearest = e;
            }
        }

        if (nearest == null) return;

        Vector2 dir = nearest.transform.position - firePoint.position;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<PlayerBullet>().Setup(dir);
    }
}
