using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText;

    // ---------- SET WEAPON ----------
    public void SetWeapon(WeaponSO weapon)
    {
        if (weapon == null) { ClearSlot(); return; }

        icon.sprite = weapon.icon;
        icon.enabled = true;

        nameText.text = weapon.weaponName;
    }

    // ---------- SET ACCESSORY ----------
    public void SetAccessory(AccessorySO acc)
    {
        if (acc == null) { ClearSlot(); return; }

        icon.sprite = acc.icon;
        icon.enabled = true;

        nameText.text = acc.itemName;
    }

    // ---------- CLEAR SLOT ----------
    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        nameText.text = "";
    }
}
