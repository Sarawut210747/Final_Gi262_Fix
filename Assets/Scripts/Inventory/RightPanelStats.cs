using TMPro;
using UnityEngine;

public class RightPanelStats : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI levelText;

    public static RightPanelStats Instance;

    void Awake()
    {
        Instance = this;
    }

    public static void UpdateStats(PlayerStats stats)
    {
        Instance.hpText.text = "HP : " + stats.currentHP + "/" + stats.maxHP;
        Instance.atkText.text = "ATK : " + stats.attackDamage;
        Instance.speedText.text = "Speed : " + stats.moveSpeed;
        Instance.levelText.text = "Level : " + stats.level;
    }
}
