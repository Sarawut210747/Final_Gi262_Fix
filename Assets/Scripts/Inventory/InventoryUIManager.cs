using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager Instance;

    [Header("UI")]
    public GameObject inventoryCanvas;

    [Header("Player")]
    public PlayerStats playerStats;
    public UnityEngine.UI.Image characterImage;

    private bool isOpen = false;

    void Awake()
    {
        Instance ??= this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleUI();
        }
    }

    public void ToggleUI()
    {
        isOpen = !isOpen;
        inventoryCanvas.SetActive(isOpen);

        if (isOpen)
        {
            UpdateUI();
            Time.timeScale = 0f;       // ถ้าต้องการให้หยุดเกม ก็ตั้ง 0
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void UpdateUI()
    {
        // อัปเดตสเตตัส
        RightPanelStats.UpdateStats(playerStats);

        // อัปเดตรูปตัวละคร
        if (characterImage != null && playerStats.characterSprite != null)
            characterImage.sprite = playerStats.characterSprite;
    }

}
