using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // ----------- ค่าพื้นฐาน -----------
    public int maxHP = 100;
    public int currentHP = 100;
    public int attackDamage = 5;
    public float moveSpeed;
    public int level = 1;
    public float skillCooldown = 3f;
    public HealthBar healthBar;
    public ItemSO[] equipments;

    // ----------- CHARACTER SPEC (อ่านจาก GameSession) -----------
    public CharacterSpecSO spec;

    void Start()
    {
        CharacterSpecSO spec = GameSession.Instance.selectedCharacter;
        if (spec == null)
        {
            Debug.LogError("No character selected from menu!");
            return;
        }

        this.spec = spec;

        maxHP = spec.maxHP;
        currentHP = spec.maxHP;
        attackDamage = spec.baseDamage;
        moveSpeed = spec.moveSpeed;
        skillCooldown = spec.skillCooldown;

        healthBar.SetMaxHP(spec.maxHP);

        // อัปเดต Stat UI
        RightPanelStats.UpdateStats(this);
        ApplySpec();

        UpdateStatsUI();
    }

    // ----------- PORTRAIT สำหรับ UI -----------
    public Sprite GetSprite()
    {
        if (spec != null && spec.portraits != null)
            return spec.portraits[0];

        return null;
    }

    // ----------- DAMAGE SYSTEM -----------
    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        healthBar.SetHP(currentHP);

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
        UpdateStatsUI();
    }
    public void UpdateStatsUI()
    {
        RightPanelStats.UpdateStats(this);
    }


    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void ApplySpec()
    {
        maxHP = spec.maxHP;
        currentHP = maxHP;

        attackDamage = spec.baseDamage;
        moveSpeed = spec.moveSpeed;
        level = 1;
    }

    // ----------- WEAPON & ACCESSORY -----------
    public System.Collections.Generic.List<WeaponSO> weapons =
        new System.Collections.Generic.List<WeaponSO>();

    public System.Collections.Generic.List<AccessorySO> accessories =
        new System.Collections.Generic.List<AccessorySO>();

    public void AddWeapon(WeaponSO w)
    {
        if (!weapons.Contains(w))
        {
            weapons.Add(w);
            attackDamage += w.baseDamage;
        }
        else
        {
            if (w.level < w.maxLevel)
            {
                w.level++;
                attackDamage += w.damagePerLevel[w.level - 1];
            }
        }

        RightPanelStats.UpdateStats(this);
    }


    public void AddAccessory(AccessorySO a)
    {
        if (!accessories.Contains(a))
        {
            accessories.Add(a);
            maxHP += a.hpBonus;
            moveSpeed += a.speedBonus;
            a.level = 1;
        }
        else
        {
            if (a.level < a.maxLevel)
            {
                a.level++;

                maxHP += a.hpBonusPerLevel;
                moveSpeed += a.speedBonusPerLevel;
            }
        }

        RightPanelStats.UpdateStats(this);
    }


    // ----------- LEVEL UP -----------
    public int GetWeaponLevel(WeaponSO w)
    {
        return w.level;
    }

    public void LevelUpWeapon(WeaponSO w)
    {
        if (w.level < w.maxLevel)
        {
            w.level++;
            attackDamage += w.damagePerLevel[w.level - 1];
        }
    }
    public void ApplySpec(CharacterSpecSO newSpec)
    {
        spec = newSpec;

        maxHP = spec.maxHP;
        currentHP = maxHP;
        attackDamage = spec.baseDamage;
        moveSpeed = spec.moveSpeed;

        RightPanelStats.UpdateStats(this);
    }
    public void RecalculateStats()
    {
        // base stat from character
        maxHP = spec.maxHP;
        attackDamage = spec.baseDamage;
        moveSpeed = spec.moveSpeed;

        // Add from weapons
        foreach (var w in weapons)
        {
            attackDamage += w.damageBonus;
            maxHP += w.hpBonus;
        }

        // Add from accessories
        foreach (var a in accessories)
        {
            moveSpeed += a.speedBonus;
        }

        // อัปเดต UI
        RightPanelStats.UpdateStats(this);
    }
    public int GetTotalDamage()
    {
        int damage = attackDamage;

        foreach (var w in weapons)
            damage += w.GetDamage();

        foreach (var a in accessories)
            damage += a.GetDamage();

        return damage;
    }

    public int GetTotalHP()
    {
        int hp = maxHP;

        foreach (var w in weapons)
            hp += w.GetHP();

        foreach (var a in accessories)
            hp += a.GetHP();

        return hp;
    }


}
