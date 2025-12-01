using UnityEngine;

public abstract class ActiveSkillSO : ScriptableObject
{
    public float cooldown = 5f;
    public abstract void Activate(PlayerStats player);
}