using UnityEngine;
using UnityEngine.UI;

public class SkillCooldownUI : MonoBehaviour
{
    public Image cooldownFill;   // วงคูลดาว
    public Image skillIcon;      // ไอคอนสกิลเดิม

    private bool isCooling = false;
    private float cooldownTime = 0;
    private float cooldownTimer = 0;

    void Update()
    {
        if (isCooling)
        {
            cooldownTimer -= Time.deltaTime;

            // อัปเดตวงคูลดาว
            cooldownFill.fillAmount = cooldownTimer / cooldownTime;

            // จบคูลดาว
            if (cooldownTimer <= 0)
            {
                isCooling = false;
                cooldownFill.fillAmount = 0;
                skillIcon.color = Color.white; // กลับมาสว่าง
            }
        }
    }

    // เรียกจากสกิลเมื่อเริ่มคูลดาว
    public void StartCooldown(float time)
    {
        isCooling = true;
        cooldownTime = time;
        cooldownTimer = time;

        // เริ่มจากเต็มวง
        cooldownFill.fillAmount = 1f;

        // ทำให้ไอคอนมืดลงเหมือนล็อค
        skillIcon.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
}
