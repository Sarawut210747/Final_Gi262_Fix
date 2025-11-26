using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public int currentExp = 0;
    public int expToNext = 20;

    [Header("UI")]
    public Slider expBar;
    //public TextMeshProUGUI leveText;
    public LevelUpUI levelUpUI;

    public void AddExp(int amount)
    {
        currentExp += amount;

        if (currentExp >= expToNext)
        {
            LevelUp();
        }

        UpdateUI();
    }

    void LevelUp()
    {
        level++;

        currentExp = 0;
        expToNext += 10;

        UpdateUI();

        Time.timeScale = 0f; // หยุดเกมให้เลือกไอเทม
        levelUpUI.ShowOptions();
    }

    void UpdateUI()
    {
        expBar.value = (float)currentExp / (float)expToNext;
    }
}
