using UnityEngine;
using TMPro;

public class ObjectiveTracker : MonoBehaviour
{
    public int totalObjectives = 9;
    private int remainingObjectives;
    
    public TextMeshProUGUI objectivesText; // UI contador de objetivos
    public TextMeshProUGUI timerText; // UI del tiempo restante
    public GameObject specialObject; // Objeto que se activa al completar los objetivos
    
    public float timeLimit = 120f; // Tiempo límite en segundos (2 minutos)
    private float currentTime;
    private bool isTimerRunning = false;

    private PlayerShooting playerShooting; // Referencia al script de disparo

    private void Start()
    {
        remainingObjectives = totalObjectives;
        UpdateUI();
        specialObject.SetActive(false); // Ocultar el objeto especial

        timerText.gameObject.SetActive(false); // El temporizador inicia oculto
        currentTime = timeLimit;

        playerShooting = FindObjectOfType<PlayerShooting>(); // Buscar el script de disparo
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();

            if (currentTime <= 0)
            {
                isTimerRunning = false;
                HandleTimeOut();
            }
        }
    }

    public void ResetTimer()
    {
        currentTime = timeLimit; // Reiniciar el temporizador a 120s
        isTimerRunning = true; // Asegurar que el temporizador inicie
        timerText.gameObject.SetActive(true); // Mostrar el temporizador
        UpdateTimerUI(); // Actualizar la UI de inmediato para evitar retrasos visuales
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        timerText.gameObject.SetActive(false); // Ocultar temporizador en UI
    }

    public void ObjectDestroyed()
    {
        remainingObjectives--;
        UpdateUI();

        if (remainingObjectives <= 0)
        {
            ActivateSpecialObject();
        }
    }

    private void UpdateUI()
    {
        objectivesText.text = "Objetivos restantes: " + remainingObjectives;
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void ActivateSpecialObject()
    {
        specialObject.SetActive(true); // Activar el objeto especial
        StopTimer(); // Detener y ocultar el temporizador

        if (playerShooting != null)
        {
            playerShooting.DisableWeapon(); // Desactivar el arma
        }
    }

    private void HandleTimeOut()
    {
        Debug.Log("⏳ Tiempo agotado, reiniciando el arma en el mapa...");
        StopTimer();
    }
}



