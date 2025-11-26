using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory inventory;

    public ItemSlot[] weaponSlots;
    public ItemSlot[] accessorySlots;

    public void Refresh()
    {
        // อาวุธ
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (i < inventory.currentWeapons.Count)
                weaponSlots[i].SetWeapon(inventory.currentWeapons[i]);
            else
                weaponSlots[i].ClearSlot();
        }

        // Accessories
        for (int i = 0; i < accessorySlots.Length; i++)
        {
            if (i < inventory.currentAccessories.Count)
                accessorySlots[i].SetAccessory(inventory.currentAccessories[i]);
            else
                accessorySlots[i].ClearSlot();
        }
    }
}
