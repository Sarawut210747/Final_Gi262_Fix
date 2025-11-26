using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int enemyCount = 5;
        public bool isBossWave = false;
        public GameObject enemyPrefab;
        public GameObject bossPrefab;

        public float waveDuration = 20f;

    }

    [Header("Settings")]
    public Transform player;
    public float spawnRadius = 10f;
    public float spawnDelay = 0.5f;

    [Header("UI")]
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;

    public Wave[] waves;

    private int currentWave = 0;
    private float timeLeft;
    private int enemiesAlive = 0;
    private bool waveActive = false;

    void Start()
    {
        StartWave(currentWave);
    }

    void StartWave(int index)
    {
        if (index >= waves.Length)
        {
            Debug.Log("All waves complete!");
            return;
        }

        Wave wave = waves[index];
        currentWave = index;

        timeLeft = wave.waveDuration;
        waveActive = true;

        waveText.text = "Wave " + (index + 1);

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave);
        }
    }
    void Update()
    {
        if (!waveActive) return;

        timeLeft -= Time.deltaTime;

        timerText.text = "Time : " + Mathf.CeilToInt(timeLeft).ToString() + "s";

        if (timeLeft <= 0)
        {
            waveActive = false;
            StartWave(currentWave + 1);
        }
    }

    void SpawnEnemy(Wave wave)
    {
        Vector2 spawnPos = (Vector2)player.position +
                           Random.insideUnitCircle.normalized * spawnRadius;

        GameObject prefabToSpawn = wave.isBossWave ? wave.bossPrefab : wave.enemyPrefab;

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            currentWave++;
            StartWave(currentWave);
        }
    }
}
