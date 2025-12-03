using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Transform player;

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float fleeDistance = 5f;
    public float shootingDistance = 8f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 6f;
    public float shootCooldown = 1.5f;
    private float shootTimer = 0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        if (GetComponent<EnemyStunFlag>()?.isStunned == true) return;

        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < fleeDistance)
            RunAway();
        else
            rb.linearVelocity = Vector2.zero;

        if (distance < shootingDistance)
            Shoot();
    }

    private void RunAway()
    {
        Vector2 dir = (transform.position - player.position).normalized;   // <<--- วิ่งหนี ไม่ใช่วิ่งเข้าหา
        rb.linearVelocity = dir * moveSpeed;

        // หันตัวบอสเข้าหาผู้เล่น (เพื่อให้อนิเมชั่นดูดี)
        Vector2 lookDir = player.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }

    private void Shoot()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer > 0) return;

        shootTimer = shootCooldown;

        GameObject b = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Vector2 dir = (player.position - transform.position).normalized;
        b.GetComponent<Rigidbody2D>().linearVelocity = dir * bulletSpeed;
    }
}
