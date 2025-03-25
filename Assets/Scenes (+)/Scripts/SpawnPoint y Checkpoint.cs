using UnityEngine;

public class SpawnPointyCheckpoint : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;
    public Transform spawnPoint;

    void Awake()
    {
        // Se inicia el checkpoint en la posición inicial del spawn o en la posición del objeto.
        lastCheckpointPosition = spawnPoint ? spawnPoint.position : transform.position;
    }

    public void GuardarCheckpoint(Vector3 checkpointPos)
    {
        lastCheckpointPosition = checkpointPos;
        Debug.Log("Checkpoint guardado en: " + lastCheckpointPosition);
    }

    public Vector3 GetLastCheckpoint()
    {
        return lastCheckpointPosition;
    }
}


