using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;

    private Vector2 direction;

    public void Setup(Vector2 dir)
    {
        direction = dir.normalized;     // เก็บทิศให้กระสุน
        Destroy(gameObject, 3f);        // กันหลุดจอ
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");

            Enemy e = other.GetComponent<Enemy>();
            if (e != null)
            {
                e.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }


}
