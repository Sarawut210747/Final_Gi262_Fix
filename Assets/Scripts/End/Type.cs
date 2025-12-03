using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Type : MonoBehaviour
{
    public float scrollSpeed = 50f;   // ความเร็วในการเลื่อน
    public float endY = 1500f;        // ตำแหน่งสุดท้ายที่อยากให้เลื่อนจนถึง
    public string nextSceneName = "MainMenu";   // จะโหลดฉากไหนต่อ (หรือปล่อยว่างก็ได้)

    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        // เลื่อนขึ้น
        rect.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // ถ้าเลื่อนสูงถึงจุดที่กำหนด → ทำสิ่งที่ต้องการ เช่น โหลดฉากใหม่
        if (rect.anchoredPosition.y >= endY)
        {
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
