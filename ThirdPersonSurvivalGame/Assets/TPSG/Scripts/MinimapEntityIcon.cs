using UnityEngine;

public class MinimapEntityIcon : MonoBehaviour
{
    public Transform target;            // Objet représenté
    public RectTransform mapArea;       // UI de la minimap
    public float mapSize = 40f;         // Zone couverte par la cam minimap
    public bool rotateWithTarget = false;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // World offset (uniquement X et Z)
        Vector3 offset = target.position - PlayerPosition();

        // Normalisation du offset pour l'échelle minimap
        float x = (offset.x / mapSize) * (mapArea.sizeDelta.x / 2f);
        float y = (offset.z / mapSize) * (mapArea.sizeDelta.y / 2f);

        // Clamp pour rester dans le cercle ou carré
        float max = mapArea.sizeDelta.x / 2f - 12f;
        x = Mathf.Clamp(x, -max, max);
        y = Mathf.Clamp(y, -max, max);

        // Placement de l'icône
        GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);

        // Rotation de l'icône (ex: player arrow)
        if (rotateWithTarget)
            transform.rotation = Quaternion.Euler(0, 0, -target.eulerAngles.y);
    }

    // Toujours centre la minimap sur le joueur
    Vector3 PlayerPosition()
    {
        // Le minimap camera suit déjà le joueur → son position = référence
        return FindObjectOfType<PlayerMovement>().transform.position;
    }
}