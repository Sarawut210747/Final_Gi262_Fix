using UnityEngine;

[CreateAssetMenu(menuName = "LevelUp/Accessory")]
public class AccessorySO : ItemSO
{
    public int hpBonus = 0;
    public int hpBonusPerLevel = 0;

    public float speedBonus = 0;
    public float speedBonusPerLevel = 0;

    public int maxLevel = 2;
    public int level = 1;

    public float[] valuePerLevel; // เช่น moveSpeed, armor, attack speed
}
