using UnityEngine;

public class texto2 : MonoBehaviour
{
    public GameObject messagePanel10; // Referencia al panel de la UI
    private bool hasBeenActivated = false; // Variable para verificar si ya se activ�

    void Start()
    {
        if (messagePanel10 != null)
            messagePanel10.SetActive(false); // Asegurarse de que el panel comience oculto
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
        if (messagePanel10 != null)
        {
            messagePanel10.SetActive(true); // Muestra el panel
            Invoke("HidePanel", 6f); // Lo oculta despu�s de 2 segundos (puedes cambiar el tiempo)
        }
    }

    void HidePanel()
    {
        if (messagePanel10 != null)
            messagePanel10.SetActive(false); // Oculta el panel
    }
}
