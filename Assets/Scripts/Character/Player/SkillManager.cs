using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private PlayerStats stats;

    private float skillTimer;

    public void Setup(CharacterSpecSO spec)
    {
        stats = GetComponent<PlayerStats>();
        skillTimer = 0;
    }

    void Update()
    {
        skillTimer -= Time.deltaTime;
        if (skillTimer <= 0)
        {
            UseSkill();
            skillTimer = stats.spec.skillCooldown;
        }
    }

    void UseSkill()
    {
        switch (stats.spec.type)
        {
            case CharacterType.Vampire:
                VampireSkill();
                break;

            case CharacterType.Elf:
                ElfSkill();
                break;

            case CharacterType.Golem:
                GolemSkill();
                break;
        }
    }

    // --------------------------
    // Vampire Skill
    // --------------------------
    void VampireSkill()
    {
        Debug.Log("Vampire Active Skill: ระเบิดเลือด");
        // → ทำดาเมจรอบตัว 25% HP ศัตรู
    }

    public void TriggerVampirePassive()
    {
        Debug.Log("Passive: Blood Aura ทำให้ศัตรูใกล้ๆติดสตัน");
        // → สร้าง aura รอบตัว
    }

    // --------------------------
    // Elf
    // --------------------------
    void ElfSkill()
    {
        Debug.Log("Elf Skill: ยิงศรแรงระเบิด 120 วิ");
    }

    // --------------------------
    // Golem
    // --------------------------
    void GolemSkill()
    {
        Debug.Log("Golem Skill: กระแทกพื้น 50% HP enemy");
    }
}
