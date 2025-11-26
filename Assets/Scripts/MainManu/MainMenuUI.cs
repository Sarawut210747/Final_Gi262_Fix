using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject characterPanel;

    [Header("Data")]
    public CharacterSpecSO[] characters;
    public MapDataSO[] maps;

    [Header("Character UI")]
    public Image portraitImage;
    public TextMeshProUGUI nameText;

    private int characterIndex = 0;
    private CharacterSpecSO pickedCharacter = null;

    void Start()
    {
        OpenMainPanel();
    }

    // --------------------------
    // หน้าแรก
    // --------------------------
    public void OpenMainPanel()
    {
        mainPanel.SetActive(true);
        characterPanel.SetActive(false);
    }

    // --------------------------
    // หน้าเลือกตัวละคร
    // --------------------------
    public void OpenCharacterPanel()
    {
        mainPanel.SetActive(false);
        characterPanel.SetActive(true);

        characterIndex = 0;
        pickedCharacter = null; // ยังไม่ pick
        UpdateCharacterUI();
    }

    // --------------------------
    // อัพเดต UI ของตัวละครปัจจุบัน
    // --------------------------
    private void UpdateCharacterUI()
    {
        var c = characters[characterIndex];

        nameText.text = c.displayName;

        if (c.portraits != null && c.portraits.Length > 0)
            portraitImage.sprite = c.portraits[0];
        else
            portraitImage.sprite = null;
    }

    // --------------------------
    // Next / Previous
    // --------------------------
    public void OnNext()
    {
        characterIndex++;
        if (characterIndex >= characters.Length)
            characterIndex = 0;

        UpdateCharacterUI();
    }

    public void OnPrev()
    {
        characterIndex--;
        if (characterIndex < 0)
            characterIndex = characters.Length - 1;

        UpdateCharacterUI();
    }

    // --------------------------
    // ปุ่ม Pick = เลือกตัวละครนี้
    // --------------------------
    public void OnPickCharacter()
    {
        pickedCharacter = characters[characterIndex];

        Debug.Log("Picked: " + pickedCharacter.displayName);
    }

    // --------------------------
    // Confirm = นำตัวที่ pick ไปให้เกมจริงโหลด
    // --------------------------
    public void OnConfirm()
    {
        if (pickedCharacter == null)
        {
            Debug.LogWarning("You must pick a character before confirming!");
            return;
        }

        GameSession.Instance.selectedCharacter = pickedCharacter;

        // สุ่มแมพ
        if (maps.Length > 0)
        {
            GameSession.Instance.selectedMap =
                maps[Random.Range(0, maps.Length)];
        }

        SceneManager.LoadScene("SampleScene"); // เปลี่ยนชื่อให้ตรงกับเกมจริง
    }

    public void OnBackButton()
    {
        OpenMainPanel();
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
