using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName;
    public Sprite icon;

    [Header("Stat Bonus")]
    public int bonusHP;
    public int bonusDamage;
    public float bonusMoveSpeed;
    public float bonusAttackSpeed;

    // ให้ class ลูก override ถ้าจำเป็น
    public virtual int GetHP() => bonusHP;
    public virtual int GetDamage() => bonusDamage;
    public virtual float GetMoveSpeed() => bonusMoveSpeed;
    public virtual float GetAttackSpeed() => bonusAttackSpeed;
}
