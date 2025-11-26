using UnityEngine;

[CreateAssetMenu(menuName = "LevelUp/Weapon")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public Sprite icon;
    public int damageBonus;
    public int hpBonus;
    public int baseDamage = 10;
    public int attackBonus = 0;
    public int level = 1;

    [Header("Level Data (Max 5 LV)")]
    public int maxLevel = 5;
    public int[] damagePerLevel;
    public float[] rangePerLevel;
}
