using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca el checkpoint
        {
            SpawnPointyCheckpoint spawnPointScript = FindObjectOfType<SpawnPointyCheckpoint>();

            if (spawnPointScript != null)
            {
                spawnPointScript.GuardarCheckpoint(transform.position);
                Debug.Log("✅ Checkpoint guardado en: " + transform.position);
            }
            else
            {
                Debug.LogWarning("⚠️ No se encontró el script SpawnPointyCheckpoint en la escena.");
            }
        }
    }
}


