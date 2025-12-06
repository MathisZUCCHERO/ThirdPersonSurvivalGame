using UnityEngine;

public class MinimapIconManager : MonoBehaviour
{
    public RectTransform minimapArea;

    public GameObject enemyIconPrefab;
    public GameObject keyIconPrefab;
    public GameObject doorIconPrefab;
    public GameObject mineIconPrefab;

    public float mapSize = 40f;

    void Start()
    {
        // Create enemy icons
        foreach (EnemyAI enemy in FindObjectsOfType<EnemyAI>())
            CreateIcon(enemy.transform, enemyIconPrefab);

        // Create key icon
        KeyPickup key = FindObjectOfType<KeyPickup>();
        if (key)
            CreateIcon(key.transform, keyIconPrefab);

        // Create door icon
        SlidingDoor door = FindObjectOfType<SlidingDoor>();
        if (door)
            CreateIcon(door.transform, doorIconPrefab);

        // Create mine icons
        foreach (LandMine mine in FindObjectsOfType<LandMine>())
            CreateIcon(mine.transform, mineIconPrefab);
    }

    void CreateIcon(Transform target, GameObject prefab)
    {
        GameObject icon = Instantiate(prefab, minimapArea);
        var iconScript = icon.GetComponent<MinimapEntityIcon>();
        iconScript.target = target;
        iconScript.mapArea = minimapArea;
        iconScript.mapSize = mapSize;
    }
}