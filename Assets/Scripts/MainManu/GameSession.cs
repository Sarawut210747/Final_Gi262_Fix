using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance;
    public CharacterSpecSO selectedCharacter;
    public MapDataSO selectedMap;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerStats ps = FindFirstObjectByType<PlayerStats>();
        ps.ApplySpec(selectedCharacter);
    }

    public void SetCharacter(CharacterSpecSO spec) => selectedCharacter = spec;
    public void SetMap(MapDataSO map) => selectedMap = map;
}
