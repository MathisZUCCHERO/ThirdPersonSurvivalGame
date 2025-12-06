using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image fillImage;          // HealthBarFill
    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth == null) return;

        float ratio = playerHealth.currentHealth / playerHealth.maxHealth;
        fillImage.fillAmount = ratio;
    }
}