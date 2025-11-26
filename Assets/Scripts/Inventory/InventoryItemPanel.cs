using UnityEngine;

public class InventoryItemPanel : MonoBehaviour
{
    public Transform itemContainer;
    public GameObject itemSlotPrefab;

    public static InventoryItemPanel Instance;

    void Awake()
    {
        Instance = this;
    }

    // public static void UpdateItems(PlayerStats stats)
    // {
    //     // โชว์ Weapon + Accessories
    //     foreach (var w in stats.weapons)
    //     {
    //         var slot = Instantiate(Instance.itemSlotPrefab, Instance.itemContainer);
    //         slot.GetComponent<ItemSlot>().SetWeapon(w);
    //     }

    //     foreach (var acc in stats.accessories)
    //     {
    //         var slot = Instantiate(Instance.itemSlotPrefab, Instance.itemContainer);
    //         slot.GetComponent<ItemSlot>().SetAccessory(acc);
    //     }
    // }
}
