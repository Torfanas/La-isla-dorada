using UnityEngine;
using TMPro;

public class Level4ObjectiveTracker : MonoBehaviour
{
    public GameObject keyObject; // La llave que se activará
    private int destroyedObjects = 0; // Contador de objetos destruidos
    private int totalTargets = 5; // Número total de objetivos
    public TextMeshProUGUI timerText; // UI del tiempo restante

    public float timeLimit = 120f; // Tiempo límite en segundos (2 minutos)
    private float currentTime;
    private bool isTimerRunning = false;

    private PlayerHealth playerHealth;

    void Start()
    {
        if (keyObject != null)
        {
            keyObject.SetActive(false); // La llave inicia oculta
        }

        currentTime = timeLimit;
        timerText.gameObject.SetActive(false); // El temporizador inicia oculto

        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
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

    public void StartTimer()
    {
        currentTime = timeLimit;
        isTimerRunning = true;
        timerText.gameObject.SetActive(true); // Mostrar temporizador en UI
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        timerText.gameObject.SetActive(false); // Ocultar temporizador en UI
    }

    public void ObjectDestroyed()
    {
        destroyedObjects++;

        if (destroyedObjects >= totalTargets)
        {
            ActivateKey();
        }
    }

    private void ActivateKey()
    {
        if (keyObject != null)
        {
            keyObject.SetActive(true); // Muestra la llave
        }
        StopTimer(); // Detener el temporizador cuando se cumplan los objetivos
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void HandleTimeOut()
    {
        Debug.Log("⏳ Tiempo agotado, perdiendo una vida...");
        playerHealth.TakeDamage();
        StopTimer();
    }
}

