using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    public GameObject panel;

    [Header("Button Options")]
    public Button[] optionButtons;
    public Image[] optionIcons;
    public TextMeshProUGUI[] optionNames;

    public WeaponSO[] weapons;
    public AccessorySO[] accessories;

    public PlayerInventory inventory;

    void Start()
    {
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void ShowOptions()
    {
        panel.SetActive(true);
        Generate3RandomChoices();
    }

    void Generate3RandomChoices()
    {
        List<object> possibleChoices = new List<object>();

        foreach (var w in weapons)
        {
            if (!inventory.weaponLevels.ContainsKey(w) ||
                inventory.weaponLevels[w] < w.maxLevel)
                possibleChoices.Add(w);
        }
        foreach (var a in accessories)
        {
            if (!inventory.accessoryLevels.ContainsKey(a) ||
                inventory.accessoryLevels[a] < a.maxLevel)
                possibleChoices.Add(a);
        }
        var selected = possibleChoices.OrderBy(x => Random.value).Take(3).ToList();

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (selected[i] is WeaponSO w)
            {
                optionIcons[i].sprite = w.icon;
                optionNames[i].text = w.weaponName + "( Lv"
                + (inventory.weaponLevels.ContainsKey(w) ? inventory.weaponLevels[w] + 1 : 1) + ")";

                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => ChooseWeapon(w));
            }
            else if (selected[i] is AccessorySO a)
            {
                optionIcons[i].sprite = a.icon;
                optionNames[i].text = a.itemName + "(Lv"
                + (inventory.accessoryLevels.ContainsKey(a) ? inventory.accessoryLevels[a] + 1 : 1) + ")";

                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => ChooseAccessory(a));
            }
        }
    }

    public void ChooseWeapon(WeaponSO weapon)
    {
        inventory.AddWeapon(weapon);
        Close();
    }

    public void ChooseAccessory(AccessorySO acc)
    {
        inventory.AddAccessory(acc);
        Close();
    }

    void Close()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
