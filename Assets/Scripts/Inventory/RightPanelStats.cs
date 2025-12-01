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
        if (Instance == null)
        {
            Debug.LogWarning("RightPanelStats: Instance ยังไม่ถูกสร้าง แต่มีการเรียก UpdateStats()");
            return;
        }

        if (Instance.hpText == null)
        {
            Debug.LogError("RightPanelStats: hpText ยังไม่ได้โยงใน Inspector!");
            return;
        }
        Instance.hpText.text = "HP : " + stats.currentHP + "/" + stats.maxHP;
        Instance.atkText.text = "ATK : " + stats.attackDamage;
        Instance.speedText.text = "Speed : " + stats.moveSpeed;
        Instance.levelText.text = "Level : " + stats.level;

        if (Instance.portraitImage != null)
            Instance.portraitImage.sprite = stats.GetSprite();
    }
}
