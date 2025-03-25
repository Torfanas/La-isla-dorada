using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject playerWeapon; // Arma del jugador (invisible al inicio)
    public GameObject weaponOnGround; // Arma visible en el suelo
    public GameObject crosshair; // Punto de mira en la UI
    public PlayerShooting playerShooting; // Referencia al script de disparo
    private ObjectiveTracker objectiveTracker; // Referencia al temporizador dentro de ObjectiveTracker

    private void Start()
    {
        objectiveTracker = FindObjectOfType<ObjectiveTracker>();

        if (objectiveTracker == null)
        {
            Debug.LogError("⚠️ No se encontró ObjectiveTracker en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerWeapon.SetActive(true);
            weaponOnGround.SetActive(false);
            crosshair.SetActive(true);
            playerShooting.EnableShooting();

            if (objectiveTracker != null)
            {
                objectiveTracker.ResetTimer(); // Usar ResetTimer() en lugar de StartTimer()
            }

            Destroy(gameObject); // Eliminar el objeto de recogida
        }
    }
}
