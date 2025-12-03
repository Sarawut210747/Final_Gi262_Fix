using UnityEngine;

public enum CharacterType
{
    Vampire,
    Elf,
    Golem
}

[CreateAssetMenu(fileName = "Character", menuName = "Game/Character")]
public class CharacterSpecSO : ScriptableObject
{
    public CharacterType type;
    public PassiveSkillSO passiveSkill;

    [Header("Stats")]
    public int maxHP = 100;
    public float moveSpeed = 3;
    public int baseDamage = 10;

    [Header("Descriptions")]
    public string skillDescription;
    public string passiveDescription;

    [Header("Skill")]
    public float skillCooldown = 5f;

    [Header("UI")]
    public string displayName;
    public Sprite[] portraits;
}
