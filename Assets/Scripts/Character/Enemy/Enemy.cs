using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp = 30;
    public int touchDamage = 10;
    public PlayerLevel playerLevel;
    int currentHp;

    void Start()
    {
        currentHp = maxHp;
        playerLevel = GameObject.FindWithTag("Player")
                             .GetComponent<PlayerLevel>();
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        Debug.Log("Enemy HP = " + currentHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Hit Player");

            PlayerStats ps = collision.collider.GetComponent<PlayerStats>();
            if (ps != null)
            {
                ps.TakeDamage(touchDamage);
            }

            Die();
        }
    }

    void Die()
    {
        FindFirstObjectByType<PlayerLevel>().AddExp(5);
        Debug.Log(name + " died!");
        Destroy(gameObject);

    }
}
