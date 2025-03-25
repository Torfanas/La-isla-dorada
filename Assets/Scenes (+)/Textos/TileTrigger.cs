using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    public GameObject messagePanel; // Referencia al panel de la UI
    private bool hasBeenActivated = false; // Variable para verificar si ya se activó

    void Start()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false); // Asegurarse de que el panel comience oculto
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenActivated) // Solo se activa si no ha sido activado antes
        {
            hasBeenActivated = true; // Marcamos que ya fue activado
            ShowPanel();
        }
    }

    void ShowPanel()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(true); // Muestra el panel
            Invoke("HidePanel", 6f); // Lo oculta después de 2 segundos (puedes cambiar el tiempo)
        }
    }

    void HidePanel()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false); // Oculta el panel
    }
}
