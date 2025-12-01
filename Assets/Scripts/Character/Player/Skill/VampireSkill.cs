using UnityEngine;
using System.Collections;

public class VampireSkill : MonoBehaviour
{
    [Header("Active Skill")]
    public float explosionRadius = 3f;
    public int explosionDamage = 30;
    public float cooldown = 10f;
    private float timer = 0f;

    [Header("Passive Skill")]
    public int killRequired = 20;
    public float auraRadius = 2.5f;
    public float auraDuration = 5f;
    public float stunDuration = 0.5f;

    public SkillCooldownUI cooldownUI;
    private int killCount = 0;
    private bool auraActive = false;
    public GameObject auraAnimObject;
    public GameObject activeSkillFX;



    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }

    // ---------------------------------------------------
    // ⭐ เรียกฟังก์ชันนี้ตอน "กดใช้สกิล Active"
    // ---------------------------------------------------
    public void UseActiveSkill()
    {
        if (timer > 0) return;

        timer = cooldown;

        // ⭐ แจ้ง UI ให้เริ่มแสดงคูลดาว
        if (cooldownUI != null)
            cooldownUI.StartCooldown(cooldown);
        StartCoroutine(PlayActiveSkillFX());
        StartCoroutine(BloodExplosion());

    }

    IEnumerator BloodExplosion()
    {
        Debug.Log("Vampire Active Skill : Blood Explosion!");

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var h in hits)
        {
            if (h.CompareTag("Enemy"))
            {
                // ถ้า Enemy มี TakeDamage
                var enemyHp = h.GetComponent<Enemy>();
                if (enemyHp != null)
                    enemyHp.TakeDamage(explosionDamage);
            }
        }

        yield return null;
    }

    // ---------------------------------------------------
    // ⭐ เรียกเมื่อตัวละครฆ่าศัตรูได้
    // ---------------------------------------------------
    public void AddKill()
    {
        killCount++;

        if (killCount >= killRequired && !auraActive)
        {
            killCount = 0;
            StartCoroutine(BloodAura());
        }
    }

    // ---------------------------------------------------
    // ⭐ Passive Aura ไม่ไปยุ่ง Movement เดิม
    // ใช้ "StunFlag" ให้ Enemy เช็กเองว่าจะหยุดไหม
    // ---------------------------------------------------
    IEnumerator BloodAura()
    {
        auraActive = true;

        // เปิด Animation Aura
        if (auraAnimObject != null)
            auraAnimObject.SetActive(true);

        float t = auraDuration;

        while (t > 0)
        {
            t -= Time.deltaTime;

            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, auraRadius);
            foreach (var h in hits)
            {
                if (h.CompareTag("Enemy"))
                {
                    EnemyStunFlag stun = h.GetComponent<EnemyStunFlag>();
                    if (stun != null)
                    {
                        stun.ApplyStun(stunDuration);
                    }
                }
            }

            yield return null;
        }

        // ปิด Animation Aura
        if (auraAnimObject != null)
            auraAnimObject.SetActive(false);

        auraActive = false;
    }
    IEnumerator PlayActiveSkillFX()
    {
        if (activeSkillFX != null)
        {
            activeSkillFX.SetActive(true);

            // รอจน Animation เล่นจบ (เช่น 0.5 วินาที)
            yield return new WaitForSeconds(0.5f);

            activeSkillFX.SetActive(false);
        }
    }



    // Gizmo ไว้ดูรัศมีสวยๆ
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, auraRadius);
    }

}
