using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public PlayerStats stats;

    // เก็บ level ของอาวุธและ accessory
    public Dictionary<WeaponSO, int> weaponLevels = new Dictionary<WeaponSO, int>();
    public Dictionary<AccessorySO, int> accessoryLevels = new Dictionary<AccessorySO, int>();

    // UI แสดงผล Stat (โยงจาก Player ใน Inspector)
    public TextMeshProUGUI statusSkillText;
    public TextMeshProUGUI skillText;
    public TextMeshProUGUI passiveText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI attackText;

    // เก็บอาวุธ 6 ชิ้นสูงสุด
    public List<WeaponSO> currentWeapons = new List<WeaponSO>();
    public List<AccessorySO> currentAccessories = new List<AccessorySO>();

    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // ----------------------------
    // เพิ่มอาวุธ
    // ----------------------------
    public void AddWeapon(WeaponSO weapon)
    {
        if (!weaponLevels.ContainsKey(weapon))
        {
            // อาวุธยังไม่มี → เพิ่มใหม่
            weaponLevels.Add(weapon, 1);
            currentWeapons.Add(weapon);

            stats.attackDamage += weapon.attackBonus;
        }
        else
        {
            // อัพเลเวลอาวุธ
            weaponLevels[weapon]++;

            stats.attackDamage += weapon.attackBonus;
        }

        RefreshUI();
    }

    // ----------------------------
    // เพิ่ม Accessory
    // ----------------------------
    public void AddAccessory(AccessorySO item)
    {
        if (!accessoryLevels.ContainsKey(item))
        {
            accessoryLevels.Add(item, 1);
            currentAccessories.Add(item);

            stats.maxHP += item.hpBonus;
            stats.moveSpeed += item.speedBonus;
        }
        else
        {
            accessoryLevels[item]++;

            stats.maxHP += item.hpBonusPerLevel;
            stats.moveSpeed += item.speedBonusPerLevel;
        }

        RefreshUI();
    }

    // ----------------------------
    // อัพเดท UI
    // ----------------------------
    void RefreshUI()
    {
        hpText.text = "HP : " + stats.currentHP + "/" + stats.maxHP;
        attackText.text = "ATK : " + stats.attackDamage;
    }
}
