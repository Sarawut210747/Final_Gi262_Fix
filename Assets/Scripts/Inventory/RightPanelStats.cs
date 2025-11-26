using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RightPanelStats : MonoBehaviour
{
    public TextMeshProUGUI hpText, atkText, speedText, levelText;
    public Image portraitImage;

    public static RightPanelStats Instance;


    void Awake() => Instance = this;


    public static void UpdateStats(PlayerStats stats)
    {
        Instance.hpText.text = "HP : " + stats.currentHP + "/" + stats.maxHP;
        Instance.atkText.text = "ATK : " + stats.attackDamage;
        Instance.speedText.text = "Speed : " + stats.moveSpeed;
        Instance.levelText.text = "Level : " + stats.level;

        if (Instance.portraitImage != null)
            Instance.portraitImage.sprite = stats.GetSprite();
    }
}
