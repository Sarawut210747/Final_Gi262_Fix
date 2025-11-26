using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterSpec
{
    public CharacterType type;
    public float skillCooldown = 5f;
}

public class PlayerStats : MonoBehaviour
{
    [Header("Base Stats")]
    public float maxHP = 100f;
    public float currentHP = 100f;
    public float attackDamage = 5f;
    public float moveSpeed = 3f;

    [Header("Level System")]
    public int level = 1;
    public int exp = 0;
    public int expToNextLevel = 20;

    [Header("Character Data")]
    public CharacterSpec spec;             // ← สำหรับเช็ค type และ skillCooldown
    public Sprite characterSprite;         // ← รูปตัวละครโชว์ในหน้า Stat

    public Dictionary<WeaponSO, int> weaponLevels = new Dictionary<WeaponSO, int>();
    public Dictionary<AccessorySO, int> accessoryLevels = new Dictionary<AccessorySO, int>();

    void Start()
    {
        currentHP = maxHP;
        RightPanelStats.UpdateStats(this);  // อัปเดตหน้า Stat UI
    }

    // -------------------------
    // Damage System
    // -------------------------
    public void TakeDamage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }

        RightPanelStats.UpdateStats(this);
    }

    void Die()
    {
        Debug.Log("Player Died");
        // ใส่ Game Over ก็ได้
    }

    // -------------------------
    // Add EXP + LevelUp
    // -------------------------
    public void AddExp(int value)
    {
        exp += value;

        if (exp >= expToNextLevel)
            LevelUp();
    }

    void LevelUp()
    {
        exp = 0;
        level++;

        // เพิ่มค่าสเตทเวลาเลเวลอัพ
        maxHP += 20;
        currentHP = maxHP;
        attackDamage += 2f;
        moveSpeed += 0.2f;

        RightPanelStats.UpdateStats(this);
    }
}
