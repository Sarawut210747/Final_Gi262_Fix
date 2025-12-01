using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 4f;
    public int damage = 5;

    private void Start()
    {
        //Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            col.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("Hit");
        }
    }
}
