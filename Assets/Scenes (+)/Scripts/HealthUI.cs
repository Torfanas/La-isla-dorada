using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHealthUI;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealthUI;
    }

    private void UpdateHealthUI(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.text = "Vidas: " + currentHealth;
        }
    }
}
