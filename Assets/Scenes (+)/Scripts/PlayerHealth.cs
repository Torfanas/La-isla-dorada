using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public TextMeshProUGUI healthText;
    private SpawnPointyCheckpoint checkpointSystem;

    public static event Action<int> OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
        checkpointSystem = FindObjectOfType<SpawnPointyCheckpoint>();

        if (checkpointSystem != null)
        {
            transform.position = checkpointSystem.GetLastCheckpoint() + Vector3.up * 1.5f;
            Debug.Log("🏁 Spawn en: " + transform.position);
        }
        else
        {
            Debug.LogWarning("⚠️ No se encontró un SpawnPointyCheckpoint en la escena.");
        }

        UpdateHealthUI(); // 🔹 Actualizamos la UI al inicio
    }

    public void TakeDamage()
    {
        currentHealth--;
        Debug.Log("💔 Vida restante: " + currentHealth);
        UpdateHealthUI(); // 🔹 Actualizamos la UI al recibir daño

        if (OnHealthChanged != null)
        {
            OnHealthChanged(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Debug.Log("💀 Juego terminado");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        if (checkpointSystem != null)
        {
            transform.position = checkpointSystem.GetLastCheckpoint() + Vector3.up * 1.5f;
            Debug.Log("🔄 Reapareciendo en checkpoint: " + transform.position);
        }
        else
        {
            Debug.LogWarning("⚠️ No se encontró un SpawnPointyCheckpoint para respawnear.");
        }

        UpdateHealthUI(); // 🔹 Aseguramos que la UI se actualice después de respawnear
    }

    public void SetCheckpoint(Vector3 checkpointPos)
    {
        if (checkpointSystem != null)
        {
            checkpointSystem.GuardarCheckpoint(checkpointPos);
            Debug.Log("✅ Checkpoint actualizado: " + checkpointPos);
        }
        else
        {
            Debug.LogWarning("⚠️ No se encontró un SpawnPointyCheckpoint para guardar el checkpoint.");
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Vidas: " + currentHealth;
            Debug.Log("🩸 UI de vidas actualizada: " + healthText.text);
        }
        else
        {
            Debug.LogWarning("⚠️ No se asignó el TextMeshProUGUI de la UI de vidas.");
        }
    }
}





