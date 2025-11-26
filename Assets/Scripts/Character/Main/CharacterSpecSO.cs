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

    [Header("Stats")]
    public float maxHP = 100;
    public float moveSpeed = 3;
    public int baseDamage = 10;

    [Header("Skill")]
    public float skillCooldown = 5f;

    [Header("UI")]
    public string displayName;
    public Sprite[] portraits;
}
